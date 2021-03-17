using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuManager : MonoBehaviour {
    public GameObject styleSelectionPanel;
    public GameObject roomSelectionPanel;
    public GameObject focusCategorySelectionPanel;
    public GameObject furnitureSelectionPanel;
    public GameObject onScreenUIPanel;
    public GameObject viewModePanel;
    public GameObject moreFurnitureCategory;
    public GameObject focusObjectWarningPanel;
    public GameObject furnitureTextureChangePanel;

    public Button textureChangeButton;
    private static MenuManager mm_instance;
    public ObjectDatabase oDB;
    public GameObject panelButtonHolder;
    public GameObject objButton;
    private List<GameObject> panelOpenOrder = new List<GameObject> { };
    //TODO panelnum to be removed
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
        panelOpenOrder.Add(styleSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        textureChangeButton.interactable = false;

    }

    private void Update() {
        
        if (InputManager.Instance.activeGameObject.texSet != TextureSet.NONE) {
            textureChangeButton.interactable = true;
        }
        else {
            textureChangeButton.interactable = false;
        }
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
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FurnitureButtonAdd(oDB.tvs);
        FurnitureButtonEnable();
    }
    public void FocusFireplaceSelection() {
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FurnitureButtonAdd(oDB.firePlace);
        FurnitureButtonEnable();
    }
    public void FocusLibrarySelection() {
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FurnitureButtonAdd(oDB.library);
        FurnitureButtonEnable();
    }
    public void FocusCoffeetableSelection() {
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FurnitureButtonAdd(oDB.coffeeTable);
        FurnitureButtonEnable();
    }
    public void SpawnSelectedObject()  {
        TurnOffAll();
        panelOpenOrder.Add(onScreenUIPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
    }
    public void FurnitureTextureChange() {
        TurnOffAll();
        panelOpenOrder.Add(furnitureTextureChangePanel);
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
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        panelNum++;
        FurnitureButtonAdd(oDB.couches);
        FurnitureButtonEnable();
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

    void FurnitureButtonAdd(ObjectPropertySet[] objToAdd) {
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

            GameObject go = Instantiate(objButton, panelButtonHolder.transform);
            go.GetComponent<Image>().sprite = objSprite;
            go.name = objName;
            go.GetComponent<ObjectToSpawn>().selectedObject = objToAdd[i];
        }
    }

    void FurnitureButtonEnable() {
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
