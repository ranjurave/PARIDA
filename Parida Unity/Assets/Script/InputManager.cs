using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Camera arCam;
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began) return;

        if (IsPointerOverUI(touch)) return;

        if (Input.GetMouseButton(0)) {
            Ray ray = arCam.ScreenPointToRay(touch.position);
            if(raycastManager.Raycast(ray, hits)){
                Pose pose = hits[0].pose;
                Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
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
}
