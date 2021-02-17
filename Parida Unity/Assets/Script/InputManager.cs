using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
    public Camera arCam;
    public ARRaycastManager raycastManager;
    public GameObject crosshair;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    private bool canGrabObject;
    private bool canPlaceObject;
    private Pose pose;
    private GameObject previousActiveGameObject;
    public GameObject activeGameObject;
    public GameObject selectedGameObject;
    private static InputManager m_instance;
    public Material highlitedMaterial;

    private string active;
    private string prev;

    // Property with setter and getter
    public static InputManager Instance {
        get {
            if (m_instance == null) {
                m_instance = GameObject.FindObjectOfType<InputManager>();
            }

            return m_instance;
        }
        set {
            m_instance = value;
        }
    }

    // Start is called before the first frame update
    void Start() {
        canPlaceObject = false;
        canGrabObject = false;
        previousActiveGameObject = null;
        activeGameObject = null;
    }

    // Update is called once per frame
    void Update() {

        
        CrosshairCalculation();
        crosshair.SetActive(canPlaceObject);


        if (Input.touchCount == 0) {
            canGrabObject = true;
            return;
        }

        touch = Input.GetTouch(0);

        if (IsPointerOverUI(touch)) return;

        // On one finger touch
        //**************************
        if (Input.touchCount == 1) {
            if (IsPointerOverUI(touch)) {
                return;
            }
            else {
                if (Input.GetTouch(0).phase == TouchPhase.Began && canPlaceObject) {
                    GameObject copy = Instantiate(selectedGameObject, crosshair.transform.position, crosshair.transform.rotation);
                    copy.name = copy.name.Replace("(Clone)", "");
                }
            }
        }
        // On two finger touch
        //*************************
        if (Input.touchCount == 2) {

            Ray ray = arCam.ScreenPointToRay(touch.position);

            if (raycastManager.Raycast(ray, hits)) {
                pose = hits[0].pose;
                Vector3 magnitude = pose.position - activeGameObject.transform.position;
                Vector3 direction = magnitude.normalized;
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                angle += 180;

                Vector3 rot = activeGameObject.transform.localEulerAngles;
                activeGameObject.transform.localEulerAngles = new Vector3(rot.x, angle, rot.z);
            }
        }


    }

    //********************
    // Methods
    //********************

    bool IsPointerOverUI(Touch touch) {

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    void CrosshairCalculation() {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);

        if (raycastManager.Raycast(ray, hits)) {


            canPlaceObject = !IsPointerOverObject(ray);
            crosshair.SetActive(canPlaceObject);
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    bool IsPointerOverObject(Ray pointingRay) {
        RaycastHit objectHit;
        if (Physics.Raycast(pointingRay, out objectHit)) {
            if (objectHit.collider != null) {
                if (canGrabObject) {
                    if (previousActiveGameObject != objectHit.collider.gameObject) {
                        if (previousActiveGameObject != null) {
                            previousActiveGameObject.transform.GetChild(0).gameObject.SetActive(false);
                        }
                        previousActiveGameObject = activeGameObject;
                        activeGameObject = objectHit.collider.gameObject;
                        activeGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        canGrabObject = false;
                        prev = "Prev : " + previousActiveGameObject.name;
                        active = "Active : " + activeGameObject.name;
                    }
                    else {
                        previousActiveGameObject.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }

                if (Input.touchCount == 1) {
                    var hitPose = hits[0].pose;
                    activeGameObject.transform.position = hitPose.position;
                }
                return true;
            }
            else
                return false;
        }
        else {
            if (activeGameObject != null) {
                activeGameObject.transform.GetChild(0).gameObject.SetActive(false);
                activeGameObject = null;
            }
        }
        return false;
    }

    //********************
    // for debugging
    //********************
    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(200, 200)), active , myRectStyle);
        GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), prev, myRectStyle);
    }
}