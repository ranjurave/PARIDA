using UnityEngine;
using UnityEngine.UI;

public class ActiveObjectDelete : MonoBehaviour {
    public Button deleteButton;
    
    void Start() {
        deleteButton.onClick.AddListener(DeleteGameObject);
        deleteButton.interactable = false;
        deleteButton.GetComponentInChildren<Text>().text = "Delete";
    }

    //TODO button text colour change
    private void Update() {
        ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
        if (activeObject == null) {
            deleteButton.interactable = false;
        } else {
            deleteButton.interactable = true;
        }
    }

    void DeleteGameObject() {
        ObjectPropertySet activeObject = InputManager.Instance.activeGameObject;
        Destroy(activeObject.gameObject);
        deleteButton.interactable = false;
    }

    //private void OnGUI() {
    //    GameObject activeObject = InputManager.Instance.activeGameObject;
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 25;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), styleSelected, myRectStyle);
    //}
}
