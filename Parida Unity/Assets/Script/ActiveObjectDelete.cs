using UnityEngine;
using UnityEngine.UI;

public class ActiveObjectDelete : MonoBehaviour {
    public Button deleteButton;
    
    // Start is called before the first frame update
    void Start() {
        deleteButton.onClick.AddListener(DeleteGameObject);
        deleteButton.interactable = false;
        deleteButton.GetComponentInChildren<Text>().text = "Delete";
    }

    // Update is called once per frame
    private void Update() {
        GameObject activeObject = InputManager.Instance.activeGameObject;
        if (activeObject == null) {
            deleteButton.interactable = false;
            deleteButton.GetComponentInChildren<Text>().text = "Delete";            
        } else {
            deleteButton.interactable = true;
            deleteButton.GetComponentInChildren<Text>().text = "Delete\n" + activeObject.name;
        }
    }

    void DeleteGameObject() {
        GameObject activeObject = InputManager.Instance.activeGameObject;
        GameObject.Destroy(activeObject);
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
