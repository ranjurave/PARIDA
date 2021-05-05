using UnityEngine;
using UnityEngine.UI;

public class ActiveObjectDelete : MonoBehaviour {
    public Button deleteButton;
    
    void Start() {
        deleteButton.onClick.AddListener(DeleteGameObject);
        deleteButton.interactable = false;
        //deleteButton.GetComponentInChildren<Text>().color = new Color(102, 102, 102, 255);
        deleteButton.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 255);
        deleteButton.GetComponentInChildren<Text>().text = "Delete";
    }

    private void Update() {
        ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
        if (activeObject == null) {
            deleteButton.interactable = false;
            deleteButton.GetComponentInChildren<Text>().color = new Color(102, 102, 102, 255);
        } else {
            deleteButton.interactable = true;
            deleteButton.GetComponentInChildren<Text>().color = new Color(255, 148, 126, 255);
        }
    }

    void DeleteGameObject() {
        ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
        Destroy(activeObject.gameObject);
        deleteButton.interactable = false;
        deleteButton.GetComponentInChildren<Text>().color = new Color(102, 102, 102, 255);
    }

    //private void OnGUI() {
    //    GameObject activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 25;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), styleSelected, myRectStyle);
    //}
}
