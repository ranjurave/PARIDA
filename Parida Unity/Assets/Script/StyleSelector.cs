using UnityEngine;
using UnityEngine.UI;

public class StyleSelector : MonoBehaviour {
    public Button StyleButton;
    public Styles style;

    void Start() {
        StyleButton.onClick.AddListener(SelectStyle);
    }

    void SelectStyle() {
        MenuManager.Instance.selectedStyle = style;
    }

    //private void OnGUI() {

    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), debugsting, myRectStyle);
    //}
}
