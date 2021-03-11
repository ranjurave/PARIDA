using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class MenuManager : MonoBehaviour {
    //public static MenuManager Instance;

    private static MenuManager mm_instance;

    public GameObject roomSelectionPanel;
    public GameObject styleSelectionPanel;
    public GameObject focusObjectSelectionPanel;
    public GameObject focusObjectTypeSelectionPanel;
    public GameObject onScreenUIPanel;
    public GameObject viewModePanel;
    public GameObject moreFurniturePanel;
    public GameObject focusObjectWarningPanel;

    public ObjectDatabase oDB;
    public GameObject buttonHolder;
    public GameObject objButton;
    private List<GameObject> panelOpenOrder = new List<GameObject> { };
    private int panelNum;
    public Styles selectedStyle { get; set; }
    private string debugString;

    //private void Awake() {
    //    Instance = this;
    //}

    public static MenuManager Instance {
        get {
            if (mm_instance == null) {
                mm_instance = GameObject.FindObjectOfType<MenuManager>();
            }

            return mm_instance;
        }
        set {
            mm_instance = value;
        }
    }

    void Start() {
        debugString = "Start";
        TurnOffAll();
        panelNum = 0;
        panelOpenOrder.Add(roomSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
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
        panelOpenOrder.Add(styleSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    }
    public void FocusObjectTypeSelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusObjectTypeSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    }
    public void FocusObjectSelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusObjectSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        DynamicButtonAdd();
        SelectiveButtonDisplay();
    }
    public void ObjectSelected()  {
        debugString = "Objcet selected";
        TurnOffAll();
        panelOpenOrder.Add(onScreenUIPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    } 

public void AddMoreObjects() {
        if (!InputManager.Instance.focusObjectPlaced) {
            TurnOffAll();
            focusObjectWarningPanel.SetActive(true);
        }
        else {
            TurnOffAll();
            panelOpenOrder.Add(moreFurniturePanel);
            panelOpenOrder.Last<GameObject>().SetActive(true);
            panelNum++;
            DynamicButtonAdd();
            SelectiveButtonDisplay();
        }
    }
    public void ViewModePanelOn() {
        TurnOffAll();
        panelOpenOrder.Add(viewModePanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        InputManager.Instance.viewModePanelOn = true;
        InputManager.Instance.canGrabObject = false;
    }
    public void EditModeOn() {
        TurnOffAll();
        panelOpenOrder.RemoveAt(panelNum);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum--;
        InputManager.Instance.viewModePanelOn = false;
    }
    public void WarningOkButton() {
        focusObjectWarningPanel.SetActive(false);
        onScreenUIPanel.SetActive(true);
    }
    public void BackButton() {
        TurnOffAll();
        panelOpenOrder.RemoveAt(panelNum);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum--;
    }

    void DynamicButtonAdd( ) {

        debugString = "add";
        int objCount = oDB.focusObjects.Length;
        Button[] objButtons = new Button[objCount];
        Texture[] imgTexture;
        imgTexture = Resources.LoadAll<Texture>("Image");

        for (int i = 0; i < oDB.focusObjects.Length; i++) {
            string objName = oDB.focusObjects[i].name;
            Styles objStyle = oDB.focusObjects[i].style; 
            Sprite objSprite = oDB.focusObjects[i].sprite; 

            GameObject go = Instantiate(objButton, buttonHolder.transform);
            go.GetComponent<Image>().sprite = objSprite;
            go.name = objName;
            Debug.Log(go.name);
            go.GetComponent<ObjectToSpawn>().selectedObject = oDB.focusObjects[i];
        }
    }

    void SelectiveButtonDisplay() {

        //debugString = "dislpay";
        List<ObjectToSpawn> allObjects = FindObjectsOfType<ObjectToSpawn>().ToList();
        allObjects.ForEach(x => {
            x.btn.interactable = false;
        });

        List<ObjectToSpawn> selectedObjects = allObjects.Where(x => x.selectedObject.style == selectedStyle).ToList();
        selectedObjects?.ForEach(x => x.btn.interactable = true);
    }


    private void OnGUI() {
        ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 40;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), debugString, myRectStyle);
    }
}