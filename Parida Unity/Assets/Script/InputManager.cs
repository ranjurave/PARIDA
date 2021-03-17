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
    public bool canGrabObject { get; set; }
    private bool canPlaceObject { get; set; }
    private bool moveTouch;
    private Pose pose;
    private ObjectPropertySet previousActiveGameObject;
    public ObjectPropertySet activeGameObject { get; set; }
    public ObjectPropertySet selectedGameObject { get; set; }
    private static InputManager im_instance;
    private float oldRotationAngle;
    public bool focusObjectPlaced { get; set; }
    public bool viewModePanelOn { get; set; }

    // Property with setter and getter
    public static InputManager Instance {
        get {
            if (im_instance == null) {
                im_instance = GameObject.FindObjectOfType<InputManager>();
            }

            return im_instance;
        }
        set {
            im_instance = value;
        }
    }

    void Start() {
        canPlaceObject = false;
        canGrabObject = false;
        focusObjectPlaced = false;
    }

    void Update() {
        CrosshairCalculation();
        crosshair.SetActive(canPlaceObject);
        TextureButtonActive();

        if (Input.touchCount == 0) {
            moveTouch = false;
            if (!viewModePanelOn) {
                canGrabObject = true;
            }
            return;
        }

        touch = Input.GetTouch(0);

        if (IsPointerOverUI(touch)) return;
        //TODO pressing button sometimes moves objects in scene. Back buttons mainly.
        // On one finger touch
        //**************************
        if (Input.touchCount == 1) {
            moveTouch = true;
            if (Input.GetTouch(0).phase == TouchPhase.Began && canPlaceObject) {
                ObjectPropertySet copy = Instantiate(selectedGameObject, crosshair.transform.position, crosshair.transform.rotation);
                focusObjectPlaced = true;
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

                if (Input.GetTouch(1).phase == TouchPhase.Began)// at the beginning of the gesture
                {
                    oldRotationAngle = angle; // there is no "jump" in the rotation
                }

                float deltaAngle = angle - oldRotationAngle;
                Vector3 rotEuler = activeGameObject.transform.localEulerAngles;
                rotEuler.y += deltaAngle;
                activeGameObject.transform.localEulerAngles = rotEuler;
                oldRotationAngle = angle;
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
            if (canPlaceObject) {
                if (viewModePanelOn) {
                    canPlaceObject = false;
                }
                else {
                    canPlaceObject = true;
                }
            }
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
                        activeGameObject = objectHit.collider.gameObject.GetComponent<ObjectPropertySet>();
                        if (!viewModePanelOn) {
                            activeGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        }
                        canGrabObject = false;
                    }
                    else {
                        activeGameObject = previousActiveGameObject;
                        if (!viewModePanelOn) {
                            activeGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        }
                        canGrabObject = false;

                    }
                }

                if (moveTouch) {
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

    void TextureButtonActive() {
        ObjectPropertySet activeObj = activeGameObject;
        if (canPlaceObject) {
            MenuManager.Instance.textureChangeButton.interactable = false;

        }
        else {
            if (activeObj.texSet != TextureSet.NONE) {
                MenuManager.Instance.textureChangeButton.interactable = true;
            }
            else {
                MenuManager.Instance.textureChangeButton.interactable = false;
            }
        }
    }

//********************
// for debugging
//********************
private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 50;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(400, 100)), activeGameObject.isActiveAndEnabled.ToString(), myRectStyle);
    }
}