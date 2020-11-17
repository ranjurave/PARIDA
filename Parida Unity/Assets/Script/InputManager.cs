using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARSubsystems;

public class InputManager : MonoBehaviour {

    public GameObjectAdjust GOA;

    public Camera arCam;
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    public GameObject crosshair;
    private bool CanPlace;
    private Pose pose;
    private RaycastHit objectHit;
    private GameObject activeGameObject;
    private string debugString;

    void Start() {
        CanPlace = false;
        debugString = "default";
    }

    // Update is called once per frame
    void Update() {
        
        crosshair.SetActive(CanPlace);
        CrosshairCalculation();

        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began) return;

        if (IsPointerOverUI(touch)) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && CanPlace) {
            debugString = "Touched";
            activeGameObject = DataHandler.Instance.furniture;
            //Following code not working!!!
            //GOA.setGameObject = activeGameObject;
            Instantiate(activeGameObject, crosshair.transform.position, crosshair.transform.rotation);
        }
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began) {
            DoubleTouchObject(touch);
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
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);

        if (raycastManager.Raycast(ray, hits)) {
            CanPlace = IsPointerOverObject();
            crosshair.SetActive(CanPlace);
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }


    void DoubleTouchObject(Touch touch) {
        activeGameObject.SetActive(false);
        //Pose rPose;
        //Ray touchRay = Camera.main.ScreenPointToRay(touch.position);

        //if (Physics.Raycast(touchRay, out objectHit, 25.0f)) {
        //    rPose.position = objectHit.rigidbody.position;
        //    float altitude = rPose.position.y;
        //    altitude += 10;
        //    objectHit.rigidbody.MovePosition(new Vector3(rPose.position.x, altitude, rPose.position.z));
        //}
    }

    bool IsPointerOverObject() {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray pointingRay = arCam.ScreenPointToRay(origin);
        //RaycastHit objectHit;

        if (Physics.Raycast(pointingRay, out objectHit)) {
            if (objectHit.collider) {
                activeGameObject = objectHit.collider.gameObject;
                return false;
            } else {
                activeGameObject = null;
                return true;
            }
        }
        activeGameObject = null;
        return true;
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        //activeGameObject = objectHit.collider.gameObject;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(200, 200)), activeGameObject.name  , myRectStyle);
    }
}
