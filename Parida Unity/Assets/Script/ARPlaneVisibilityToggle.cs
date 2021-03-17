using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.XR.ARSubsystems;

public class ARPlaneVisibilityToggle : MonoBehaviour {
    private ARPlaneManager planeManager;
    public Button toggleButton;
    private bool planeAROn;
    
    private void Awake() {
        planeManager = GetComponent<ARPlaneManager>();
        planeAROn = true;
        toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Hide AR Planes";
    }

    //TODO hide planes when in view mode
    public void SetAllPanelsActive() {
        if (planeAROn) {
            planeManager.enabled = false;
            foreach (var plane in planeManager.trackables) {
                plane.gameObject.SetActive(false);
            }
            toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Show AR Planes";
            planeAROn = false;
        }
        else{
            planeManager.enabled = true;
            foreach (var plane in planeManager.trackables) {
                plane.gameObject.SetActive(true);
            }
            //toggleButton.GetComponent<Text>().text = "Hide AR Planes";
            toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Hide AR Planes";
            planeAROn = true;
        }
    }
    //private void OnGUI() {
    //    ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), planeAROn.ToString(), myRectStyle);
    //}
}
