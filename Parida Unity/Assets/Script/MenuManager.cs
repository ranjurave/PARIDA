using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuManager : MonoBehaviour {
    public GameObject styleSelectionPanel;
    public GameObject roomSelectionPanel;
    public GameObject focusCategorySelectionPanel;
    public GameObject focusFurnitureSelectionPanel;
    public GameObject onScreenUIPanel;
    public GameObject viewModePanel;
    public GameObject moreFurnitureCategory;
    public GameObject moreFurnitureSelection;
    public GameObject focusObjectWarningPanel;

    private static MenuManager mm_instance;
    public ObjectDatabase oDB;
    public GameObject focusButtonHolder;
    public GameObject moreButtonHolder;
    public GameObject objButton;
    private List<GameObject> panelOpenOrder = new List<GameObject> { };
    private int panelNum;
    public Styles selectedStyle { get; set; }
    public Category selectedCategory { get; set; }
    //private string debugString;

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
        TurnOffAll();
        panelNum = 0;
        //panelOpenOrder.Add(styleSelectionPanel);
        panelOpenOrder.Add(moreFurnitureCategory);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }
    public void TurnOffAll() {
        List<DisplayPanel> allPanels = FindObjectsOfType<DisplayPanel>().ToList();
        allPanels.ForEach(x => {
            x.gameObject.SetActive(false);
        });
    }
    public void RoomSelection() {
        TurnOffAll();
        panelOpenOrder.Add(roomSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    }
    public void FocusCategorySelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusCategorySelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    }
    public void FocusTVSelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusFurnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FocusButtonAdd(oDB.tvs);
        FocusButtonEnable();
    }
    public void FocusFireplaceSelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusFurnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FocusButtonAdd(oDB.firePlace);
        FocusButtonEnable();
    }
    public void FocusLibrarySelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusFurnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FocusButtonAdd(oDB.library);
        FocusButtonEnable();
    }
    public void FocusCoffeetableSelection() {
        TurnOffAll();
        panelOpenOrder.Add(focusFurnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FocusButtonAdd(oDB.coffeeTable);
        FocusButtonEnable();
    }
    public void SpawnSelectedObject()  {
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
            panelOpenOrder.Add(moreFurnitureCategory);
            panelOpenOrder.Last<GameObject>().SetActive(true);
            panelNum++;
        }
    }
    public void moreCouchSelection() {
        TurnOffAll();
        panelOpenOrder.Add(moreFurnitureSelection);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        MoreFurnitureButtonAdd(oDB.couches);
        MoreFurnitureButtonEnable();
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

    //TODO:- Create one dynamic panel for focus-furniture and more-furniture
    //TODO:- focusObjectPlaced boolean to be rewritten to match to above change
    void FocusButtonAdd(ObjectPropertySet[] objToAdd) {
        List<ObjectToSpawn> previousButtons = FindObjectsOfType<ObjectToSpawn>().ToList();
        for (int i = 0; i < previousButtons.Count; i++) {
            Destroy(previousButtons[i].gameObject);
        }

        int objCount = oDB.tvs.Length;
        int objc = objToAdd.Length;

        for (int i = 0; i < objToAdd.Length; i++) {
            string objName = objToAdd[i].name;
            Styles objStyle = objToAdd[i].style;
            Sprite objSprite = objToAdd[i].sprite;

            GameObject go = Instantiate(objButton, focusButtonHolder.transform);
            go.GetComponent<Image>().sprite = objSprite;
            go.name = objName;
            go.GetComponent<ObjectToSpawn>().selectedObject = objToAdd[i];
        }
    }

    void FocusButtonEnable() {
        List<ObjectToSpawn> allButtons = FindObjectsOfType<ObjectToSpawn>().ToList();
        allButtons.ForEach(x => {
            x.btn.interactable = false;
        });

        List<ObjectToSpawn> selectedButtons = allButtons.Where(x => x.selectedObject.style == selectedStyle).ToList();
        selectedButtons?.ForEach(x => x.btn.interactable = true);
    }

    void MoreFurnitureButtonAdd(ObjectPropertySet[] objToAdd) {
        List<ObjectToSpawn> previousButtons = FindObjectsOfType<ObjectToSpawn>().ToList();
        for (int i = 0; i < previousButtons.Count; i++) {
            Destroy(previousButtons[i].gameObject);
        }

        int objCount = oDB.tvs.Length;
        int objc = objToAdd.Length;

        for (int i = 0; i < objToAdd.Length; i++) {
            string objName = objToAdd[i].name;
            Styles objStyle = objToAdd[i].style;
            Sprite objSprite = objToAdd[i].sprite;

            GameObject go = Instantiate(objButton, moreButtonHolder.transform);
            go.GetComponent<Image>().sprite = objSprite;
            go.name = objName;
            go.GetComponent<ObjectToSpawn>().selectedObject = objToAdd[i];
        }
    }

    void MoreFurnitureButtonEnable() {
        List<ObjectToSpawn> allButtons = FindObjectsOfType<ObjectToSpawn>().ToList();
        allButtons.ForEach(x => {
            x.btn.interactable = false;
        });

        List<ObjectToSpawn> selectedButtons = allButtons.Where(x => x.selectedObject.style == selectedStyle).ToList();
        selectedButtons?.ForEach(x => x.btn.interactable = true);
    }

    //private void OnGUI() {
    //    ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), debugString, myRectStyle);
    //}
}
