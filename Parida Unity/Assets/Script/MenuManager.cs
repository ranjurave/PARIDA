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
    public GameObject selectedObject;
    private string debugstring;

    //public GameObject btn;
    //public Transform buttonHolder;
    //Texture[] imgTexture;

    void Start() {
        debugstring = "----------";
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(false);
    }

    public void StyleSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
    }
    public void FocusObjectTypeSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(true);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(false);
    }
    public void FocusObjectSelection() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(true);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(false);
    }
    public void ObjectSelected() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        furnitureToPlace.SetActive(false);
        onScreenUI.SetActive(true);
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
    public void BackButtonFocusObject() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(true);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
    }
    public void BackButtonFocusObjectType() {
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
    }
    public void BackButtonStyleSelection() {
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        onScreenUI.SetActive(false);
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
    //void ButtonLoader() {
    //    imgTexture = Resources.LoadAll<Texture>("MoreFurnitureImage");
    //    foreach (Texture img in imgTexture) {
    //        GameObject furnitureButton = Instantiate(btn as GameObject);
    //        furnitureButton.transform.SetParent(buttonHolder);
    //        furnitureButton.GetComponent<RawImage>().texture = img;

    //        string textureName = img.name;
    //        furnitureButton.GetComponent<Button>().onClick.AddListener(() => OnAddObjectClick(textureName));
    //        //furnitureButton.GetComponent<Text>().text = img.name;
    //    }
    //}

    //public void OnAddObjectClick(string furnitureName) {
    //    debugstring = furnitureName;
    //    selectedObject = GameObject.Find(furnitureName);
    //    InputManager.Instance.selectedGameObject = selectedObject;
    //    ObjectSelected();
    //    //Renderer rend = selectedObject.GetComponent<Renderer>();
    //    //rend.material.mainTexture = Resources.Load<Texture>("MoreFurnitureImage" + furnitureName);
    //}

    //private void OnGUI() {
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 25;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 100), new Vector2(400, 100)), selectedObject.name, myRectStyle);
    //}
}
