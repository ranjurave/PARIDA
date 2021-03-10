using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreObjectToSpawn : MonoBehaviour {
    public Button btn;
    public MenuManager mm { get; set; }
    public ObjectPropertySet selectedObject { get; set; }

    public string debugstring;

    // Start is called before the first frame update
    void Start() {
        debugstring = "panellllllllll";
        btn.onClick.AddListener(AssignObject);
    }

    void AssignObject() {
        debugstring = "in Method";
        InputManager.Instance.selectedGameObject = selectedObject;
        mm.AddMoreObjects();
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 40;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 500), new Vector2(200, 200)), debugstring, myRectStyle);
    }
}
