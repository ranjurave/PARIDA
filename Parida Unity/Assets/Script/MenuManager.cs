using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour {
    public GameObject selectedFocus;
    public GameObject onScreenUI;
    public GameObject roomSelection;
    public GameObject styleSelection;
    public GameObject focusObjectSelection;
    public GameObject focusObjectTypeSelection;
    public GameObject furnitureToPlace;
    public GameObject focusObjectWarning;
    public GameObject viewModePanel;
    public string selectedStyle;
    public string testString;
    private string debugString;

    void Start() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
        furnitureToPlace.SetActive(false);
        viewModePanel.SetActive(false);
        debugString = selectedStyle;
    }

    public void StyleSelection() {

        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        viewModePanel.SetActive(false);
        debugString = selectedStyle;
    }
    public void FocusObjectTypeSelection() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(true);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        viewModePanel.SetActive(false);
        debugString = selectedStyle;
    }
    public void FocusObjectSelection() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
        viewModePanel.SetActive(false);
        debugString = selectedStyle;
        SelectiveButtonDisplay();
    }
    public void ObjectSelected() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        viewModePanel.SetActive(false);
        onScreenUI.SetActive(true);
    }
    public void AddMoreObjects() {
        if (!InputManager.Instance.focusObjectPlaced) {
            focusObjectWarning.SetActive(true);
            roomSelection.SetActive(false);
            styleSelection.SetActive(false);
            focusObjectTypeSelection.SetActive(false);
            focusObjectSelection.SetActive(false);
            onScreenUI.SetActive(false);
            furnitureToPlace.SetActive(false);
            viewModePanel.SetActive(false);
        }
        else {
            focusObjectWarning.SetActive(false);
            roomSelection.SetActive(false);
            styleSelection.SetActive(false);
            focusObjectTypeSelection.SetActive(false);
            focusObjectSelection.SetActive(false);
            onScreenUI.SetActive(false);
            viewModePanel.SetActive(false);
            furnitureToPlace.SetActive(true);
        }
    }
    public void ViewModePanelOn() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(false);
        viewModePanel.SetActive(true);
        InputManager.Instance.viewModePanelOn = true;
        InputManager.Instance.canGrabObject = false;
    }
    public void EditModeOn() {
        focusObjectWarning.SetActive(false);
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(true);
        viewModePanel.SetActive(false);
        InputManager.Instance.viewModePanelOn = false;
    }
    public void BackButtonFocusObject() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(true);
        focusObjectSelection.SetActive(false);
    }
    public void BackButtonFocusObjectType() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
    }
    public void BackButtonStyleSelection() {
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
    }
    public void BackOnScreenUI() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(true);
        onScreenUI.SetActive(false);
    }
    public void BackAddMoreObjects() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(true);
        furnitureToPlace.SetActive(false);
    }

    void SelectiveButtonDisplay() {
        //string tag1 = "boh";
        //GameObject.FindGameObjectWithTag(tag1).SetActive(false);
        //debugString = selectedStyle;
        //selectedStyle = "Bohemian";
        Button[] taggedBtn;
        taggedBtn = FindObjectsOfType<Button>();
        foreach (Button btn in taggedBtn) {
            if (btn.tag == selectedStyle) {
                btn.interactable = false;
            }
        }
    }

    private void OnGUI() {
        GameObject activeObject = InputManager.Instance.activeGameObject;
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 15;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), "var" + selectedStyle, myRectStyle);
    }
}
