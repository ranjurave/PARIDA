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

    void Start() {
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
        furnitureToPlace.SetActive(false);
    }

    public void StyleSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
    }
    public void FocusObjectTypeSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(true);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
    }
    public void FocusObjectSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
    }
    public void ObjectSelected() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(true);
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

    // TODO To check if focus object is placed
    public void AddMoreObjects() {  
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
        furnitureToPlace.SetActive(true);
    }
    public void BackAddMoreObjects() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(true);
        furnitureToPlace.SetActive(false);
    }
}
