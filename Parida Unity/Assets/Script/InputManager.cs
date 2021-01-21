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
    private bool CanPlace;
    private Pose pose;
    public GameObject activeGameObject;

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
    }

    // Update is called once per frame
    void Update() {
        CrosshairCalculation();
        crosshair.SetActive(CanPlace);

        if (Input.touchCount == 0) return;
        
        touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began) return;

        if (IsPointerOverUI(touch)) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && CanPlace) {
            activeGameObject = DataHandler.Instance.furniture;
            GameObject copy = Instantiate(activeGameObject, crosshair.transform.position, crosshair.transform.rotation);
            copy.name = copy.name.Replace("(Clone)", "");
        }       

        if (CanPlace) {
            Vector3 loc;
            loc = activeGameObject.transform.position;
            loc.x = 0;
            loc.z = 0;
            activeGameObject.transform.position = loc;
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
            CanPlace = !IsPointerOverObject(ray);
            crosshair.SetActive(CanPlace);
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    bool IsPointerOverObject(Ray pointingRay) {
        RaycastHit objectHit;

        if (Physics.Raycast(pointingRay, out objectHit)) {
            if (objectHit.collider != null) {
                activeGameObject = objectHit.collider.gameObject;
                return true;
            } else {
                activeGameObject = null;
                return false;
            }
        }
        activeGameObject = null;
        return false;
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(200, 200)), activeGameObject?.name, myRectStyle);
    }
}