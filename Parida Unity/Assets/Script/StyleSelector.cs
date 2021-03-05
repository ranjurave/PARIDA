using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum Style {
    Bohemian,
    MidCentury,
    Modern,
    Minimalistic
}

public class StyleSelector : MonoBehaviour {
    public Button StyleButton;
    public MenuManager mm;

    void Start() {
        StyleButton.onClick.AddListener(SelectStyle);

    }

    void SelectStyle() {
        mm.selectedStyle = StyleButton.GetComponentInChildren<TextMeshProUGUI>().text;
        mm.FocusObjectTypeSelection();
    }
    //private void OnGUI() {
    //    GameObject activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 25;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), mm.debugstyle, myRectStyle);
    //}
}
