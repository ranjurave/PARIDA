using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARSubsystems;

public class InputManager : MonoBehaviour {
    public Camera arCam;
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    public GameObject crosshair;
    private Pose pose;

    void Start() {
        crosshair.SetActive(true);
    }
    // Update is called once per frame
    void Update() {
        CrosshairCalculation();
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began) return;

        if (IsPointerOverUI(touch)) return;
        
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
        Instantiate(DataHandler.Instance.furniture, crosshair.transform.position, crosshair.transform.rotation);
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
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Need to try this...................................
    //void CrosshairCalculation2() {
    //    List<ARRaycastHit> hits2 = new List<ARRaycastHit>();
    //    raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits2, TrackableType.Planes);

    //    if (hits2.Count > 0) {
    //        //crosshair.SetActive(true);
    //        crosshair.transform.position = hits2[0].pose.position;
    //        crosshair.transform.rotation = hits2[0].pose.rotation;

    //    }
    //}
}
