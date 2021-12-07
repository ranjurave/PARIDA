using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Collections;

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
    public GameObject bohemianDescriptionPanel;
    public GameObject modernDescriptionPanel;
    public GameObject underDevPanel;

    public Button textureChangeButton;
    private string placementMessage;
    private static MenuManager mm_instance;
    public ObjectDatabase oDB;
    public MaterialDatabase mDB;
    public GameObject panelButtonHolder;
    public GameObject TextureButtonHolder;
    public GameObject objButton;
    public GameObject matButton;
    private List<GameObject> panelOpenOrder = new List<GameObject> { };
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
        textureChangeButton.interactable = false;
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        FirstPanel();
    }

    public void FirstPanel() {
        panelOpenOrder.Clear();
        panelOpenOrder.Add(styleSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }

    public void UnderDev() {
        TurnOffAll();
        underDevPanel.SetActive(true);
    }
    private void Update() {
        if (InputManager.Instance.activeGameObject) {
            if (InputManager.Instance.activeGameObject.texSet != TextureSet.NONE) {
                textureChangeButton.interactable = true;
            }
            else {
                textureChangeButton.interactable = false;
            }
        }
    }

    public void TurnOffAll() {
        List<DisplayPanel> allPanels = FindObjectsOfType<DisplayPanel>().ToList();
        allPanels.ForEach(x => {
            x.gameObject.SetActive(false);
        });
    }
    public void ShowStyleDescription() {
        InputManager.Instance.editPanelOn = false;
        if (selectedStyle == Styles.BOHEMIAN) {
            bohemianDescriptionPanel.SetActive(true);
        }
        if (selectedStyle == Styles.MODERN) {
            modernDescriptionPanel.SetActive(true);
        }
    }
    public void RoomSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(roomSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }
    public void FocusCategorySelection() {
        placementMessage = "Pick a furniture as focus object";
        furnitureSelectionPanel.GetComponentInChildren<TextMeshProUGUI>().text = placementMessage;
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(focusCategorySelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }
    public void FocusTVSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.tvs);
        FurnitureButtonEnable();
    }
    public void FocusBookShelfSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.bookShelf);
        FurnitureButtonEnable();
    }
    public void FocusCoffeetableSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.coffeeTable);
        FurnitureButtonEnable();
    }
    public void FocusObjectCheck() {
        InputManager.Instance.editPanelOn = false;
        if (InputManager.Instance.focusObjectPlaced) {
            AddMoreObjects();
        }
        else {
            FocusCategorySelection();
        }
    }
    public void SpawnSelectedObject() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(onScreenUIPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        StartCoroutine(DelayEditPanel());
        //InputManager.Instance.editPanelOn = true;
    }

    public void FurnitureTextureChange() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureTextureChangePanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        TextureButtonAdd(InputManager.Instance.activeGameObject.materialSet);
    }

    public void AddMoreObjects() {
        InputManager.Instance.editPanelOn = false;
        placementMessage = "Place around the focus object";
        furnitureSelectionPanel.GetComponentInChildren<TextMeshProUGUI>().text = placementMessage;
        if (!InputManager.Instance.focusObjectPlaced) {
            TurnOffAll();
            focusObjectWarningPanel.SetActive(true);
        }
        else {
            TurnOffAll();
            panelOpenOrder.Add(moreFurnitureCategory);
            panelOpenOrder.Last<GameObject>().SetActive(true);
        }
    }
    public void moreCouchSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.couches);
        FurnitureButtonEnable();
    }
    public void moreFloorLampSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.floorLamp);
        FurnitureButtonEnable();
    }
    public void moreChairSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.chairs);
        FurnitureButtonEnable();
    }
    public void morePlantsSelection() {
        InputManager.Instance.editPanelOn = false;
        TurnOffAll();
        panelOpenOrder.Add(furnitureSelectionPanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        FurnitureButtonAdd(oDB.plants);
        FurnitureButtonEnable();
    }
    public void ViewModePanelOn() {
        InputManager.Instance.editPanelOn = false;
        if (InputManager.Instance.activeGameObject) {
            InputManager.Instance.activeGameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (InputManager.Instance.previousActiveGameObject) {
            InputManager.Instance.previousActiveGameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        InputManager.Instance.crosshair.SetActive(false);
        InputManager.Instance.viewModePanelOn = true;
        TurnOffAll();
        panelOpenOrder.Add(viewModePanel);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }

    public void EditModeOn() {
        TurnOffAll();
        panelOpenOrder.RemoveAt(panelOpenOrder.Count - 1);
        panelOpenOrder.Last<GameObject>().SetActive(true);
        InputManager.Instance.crosshair.SetActive(true);
        InputManager.Instance.viewModePanelOn = false;
        StartCoroutine(DelayEditPanel());
    }
    //TODO to fix. Not delaying atm.
    private IEnumerator DelayEditPanel() {
        yield return new WaitForSeconds(1.0f);
        InputManager.Instance.editPanelOn = true;
    }
    public void UnderDevOkButton() {
        underDevPanel.SetActive(false);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }
    public void WarningOkButton() {
        focusObjectWarningPanel.SetActive(false);
        onScreenUIPanel.SetActive(true);
    }
    public void BohemianOkButton() {
        bohemianDescriptionPanel.SetActive(false);
        RoomSelection();
    }
    public void ModernOkButton() {
        modernDescriptionPanel.SetActive(false);
        RoomSelection();
    }
    public void BackButton() {
        TurnOffAll();
        panelOpenOrder.RemoveAt(panelOpenOrder.Count - 1);
        panelOpenOrder.Last<GameObject>().SetActive(true);
    }
    public void DescriptionBackButton() {
        TurnOffAll();
        FirstPanel();
    }

    void FurnitureButtonAdd(ObjectPropertySet[] objToAdd) {
        List<ObjectToSpawn> previousButtons = FindObjectsOfType<ObjectToSpawn>().ToList();
        for (int i = 0; i < previousButtons.Count; i++) {
            Destroy(previousButtons[i].gameObject);
        }

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

        List<ObjectToSpawn> selectedButtons = allButtons.Where(x => x.selectedObject.style == selectedStyle || x.selectedObject.style == Styles.ALL).ToList();
        selectedButtons?.ForEach(x => x.btn.interactable = true);
    }

    void TextureButtonAdd(ObjectMaterialSet[] objMatToAdd) {
        List<MaterialToApply> previousButtons = FindObjectsOfType<MaterialToApply>().ToList();
        for (int i = 0; i < previousButtons.Count; i++) {
            Destroy(previousButtons[i].gameObject);
        }

        for (int i = 0; i < objMatToAdd.Length; i++) {
            Sprite objSprite = objMatToAdd[i].matImage;
            Material mat = objMatToAdd[i].materialOption;

            GameObject go = Instantiate(matButton, TextureButtonHolder.transform);
            go.GetComponent<Image>().sprite = objSprite;
            go.GetComponent<MaterialToApply>().pickedMaterial = mat;
            go.GetComponent<MaterialToApply>().toChangeObject = InputManager.Instance.activeGameObject;
        }
    }
    //private void OnGUI() {
    //    ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(50, 200), new Vector2(200, 100)), InputManager.Instance.editPanelOn.ToString(), myRectStyle);
    //}
}
