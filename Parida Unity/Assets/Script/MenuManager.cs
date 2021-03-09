using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class MenuManager : MonoBehaviour {
    public GameObject roomSelectionPanel;
    public GameObject styleSelectionPanel;
    public GameObject focusObjectSelectionPanel;
    public GameObject focusObjectTypeSelectionPanel;
    public GameObject onScreenUIPanel;
    public GameObject viewModePanel;
    public GameObject moreFurniturePanel;
    public GameObject focusObjectWarningPanel;
    public Styles selectedStyle { get; set; }
    private string debugString;

    void Start() {
        TurnOffAll();
        moreFurniturePanel.SetActive(true);
        //roomSelectionPanel.SetActive(true);
    }
    public void TurnOffAll() {
        focusObjectWarningPanel.SetActive(false);
        roomSelectionPanel.SetActive(false);
        styleSelectionPanel.SetActive(false);
        focusObjectTypeSelectionPanel.SetActive(false);
        focusObjectSelectionPanel.SetActive(false);
        onScreenUIPanel.SetActive(false);
        moreFurniturePanel.SetActive(false);
        viewModePanel.SetActive(false);
    }



    public void StyleSelection() {
        TurnOffAll();
        styleSelectionPanel.SetActive(true);
    }
    public void FocusObjectTypeSelection() {
        TurnOffAll();
        focusObjectTypeSelectionPanel.SetActive(true);
    }
    public void FocusObjectSelection() {
        TurnOffAll();
        focusObjectSelectionPanel.SetActive(true);
        SelectiveButtonDisplay();
    }
    public void ObjectSelected() {
        TurnOffAll();
        onScreenUIPanel.SetActive(true);
    }
    public void AddMoreObjects() {
        if (!InputManager.Instance.focusObjectPlaced) {
            TurnOffAll();
            focusObjectWarningPanel.SetActive(true);
        }
        else {
            TurnOffAll();
            moreFurniturePanel.SetActive(true);
            SelectiveButtonDisplay();
        }
    }
    public void ViewModePanelOn() {
        TurnOffAll();
        viewModePanel.SetActive(true);
        InputManager.Instance.viewModePanelOn = true;
        InputManager.Instance.canGrabObject = false;
    }
    public void EditModeOn() {
        TurnOffAll();
        onScreenUIPanel.SetActive(true);
        InputManager.Instance.viewModePanelOn = false;
    }
    public void BackButtonFocusObject() {
        TurnOffAll();
        focusObjectTypeSelectionPanel.SetActive(true);
    }
    public void BackButtonFocusObjectType() {
        TurnOffAll();
        styleSelectionPanel.SetActive(true);
    }
    public void BackButtonStyleSelection() {
        TurnOffAll();
        roomSelectionPanel.SetActive(true);
    }
    public void BackOnScreenUI() {
        TurnOffAll();
        focusObjectSelectionPanel.SetActive(true);
    }
    public void BackAddMoreObjects() {
        TurnOffAll();
        onScreenUIPanel.SetActive(true);
    }

    void SelectiveButtonDisplay() {
        List<ObjectToSpawn> allObjects = FindObjectsOfType<ObjectToSpawn>().ToList();
        allObjects.ForEach(x => x.btn.interactable = false);

        List<ObjectToSpawn> selectedObjects = allObjects.Where(x => x.selectedObject.style == selectedStyle).ToList();
        selectedObjects.ForEach(x => x.btn.interactable = true);
    }

    //private void OnGUI() {
    //    ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 15;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), "var" + selectedStyle, myRectStyle);
    //}
}
