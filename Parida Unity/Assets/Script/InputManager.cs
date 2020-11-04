﻿using System.Collections;
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
    private bool CanPlace;

    void Start() {
        crosshair.SetActive(false);
        CanPlace = false;
    }

    // Update is called once per frame
    void Update() {
        CrosshairCalculation();
        touch = Input.GetTouch(0);
        IsPointerOverObject();

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began) return;

        if (IsPointerOverUI(touch)) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && CanPlace) {
            Instantiate(DataHandler.Instance.furniture, crosshair.transform.position, crosshair.transform.rotation);

        }
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began) {
            //DoubleTouchObject(touch);
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
            crosshair.SetActive(true);
            CanPlace = true;
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    
    void DoubleTouchObject(Touch touch) {
        Pose rPose;
        Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hitObject;
        if (Physics.Raycast(touchRay, out hitObject, 25.0f)) {
            rPose.position = hitObject.rigidbody.position;
            float altitude = rPose.position.y;
            altitude += 10;
            hitObject.rigidbody.MovePosition(new Vector3(rPose.position.x, altitude, rPose.position.z));
        }
    }

    void IsPointerOverObject() {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray pointingRay = arCam.ScreenPointToRay(origin);
        RaycastHit objectHit;

        if (Physics.Raycast(pointingRay, out objectHit)) {
            if (objectHit.collider) {
                crosshair.SetActive(false);
            } else {
                crosshair.SetActive(true);
            }
        }
    }

}