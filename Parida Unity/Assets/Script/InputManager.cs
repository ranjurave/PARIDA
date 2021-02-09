using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
    public Camera arCam;
    public ARRaycastManager raycastManager;
    public GameObject crosshair;
    private bool canGrabObject;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    private bool CanPlace;
    private Pose pose;
    public GameObject activeGameObject;
    public GameObject selectedGameObject;
    private string test;
    private static InputManager m_instance;

    public static InputManager Instance {
        get {
            if (m_instance == null) {
                m_instance = GameObject.FindObjectOfType<InputManager>();
            }
            return m_instance;
        }
    }

    void Start() {
        CanPlace = false;
        canGrabObject = false;
        activeGameObject = selectedGameObject;
    }

    // Update is called once per frame
    void Update() {
        CrosshairCalculation();
        crosshair.SetActive(CanPlace);

        if (Input.touchCount == 0) {
            canGrabObject = true;
            return;
        }

        touch = Input.GetTouch(0);

        if (IsPointerOverUI(touch)) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && CanPlace) {
            //activeGameObject = DataHandler.Instance.furniture;
            //activeGameObject = selectedGameObject;
            GameObject copy = Instantiate(activeGameObject, crosshair.transform.position, crosshair.transform.rotation);
            copy.name = copy.name.Replace("(Clone)", "");
        }

        if (Input.touchCount == 2) {

            Ray ray = arCam.ScreenPointToRay(touch.position);   

            if (raycastManager.Raycast(ray, hits)) {
                pose = hits[0].pose;
                Vector3 magnitude = pose.position - activeGameObject.transform.position;
                Vector3 direction = magnitude.normalized;
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                angle += 180;

                //test = angle + " \n" + pose.position;

                Vector3 rot = activeGameObject.transform.localEulerAngles;
                activeGameObject.transform.localEulerAngles = new Vector3(rot.x, angle, rot.z);
            }
        }
    }

    bool IsPointerOverUI(Touch touch) {

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    void CrosshairCalculation() {
        test = "crosssss";
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);

        if (raycastManager.Raycast(ray, hits)) {
            CanPlace = !IsPointerOverObject(ray);
            crosshair.SetActive(CanPlace);
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    bool IsPointerOverObject(Ray pointingRay) {
        test = "over object";
        RaycastHit objectHit;

        if (Physics.Raycast(pointingRay, out objectHit)) {
            if (objectHit.collider != null) {
                if (canGrabObject) {
                    activeGameObject = objectHit.collider.gameObject;
                    canGrabObject = false;
                }
                if (Input.touchCount == 1) {
                    var hitPose = hits[0].pose;
                    activeGameObject.transform.position = hitPose.position;
                }
                return true;
            } else {
                //activeGameObject = null;
                return false;
            }
        }
        //activeGameObject = null;
        return false;
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(200, 200)), activeGameObject.name, myRectStyle);
    }
}