using UnityEngine;
using UnityEngine.UI;

public class GameObjectDelete : MonoBehaviour
{
    public Button DeleteButton;
    private GameObject m_prevActiveGameObject;

    // Start is called before the first frame update
    void Start()
    {
        m_prevActiveGameObject = null;

        DeleteButton.onClick.AddListener(DeleteGameObject);
        //DeleteButton.gameObject.SetActive(false);
        DeleteButton.interactable = false;
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject activeObject = InputManager.Instance.activeGameObject;
        if (activeObject != m_prevActiveGameObject) {

            if (activeObject != null) {
                Debug.LogFormat("New active object '{0}'", activeObject.name);
                //DeleteButton.gameObject.SetActive(true);
                DeleteButton.interactable = true;
                DeleteButton.GetComponentInChildren<Text>().text = "Delete\n" + activeObject.name;
            } else {
                Debug.LogFormat("No active object");
                //DeleteButton.gameObject.SetActive(false);
                DeleteButton.interactable = false;
            }
            m_prevActiveGameObject = activeObject;
        }
    }

    void DeleteGameObject()
    {
        GameObject activeObject = InputManager.Instance.activeGameObject;
        Debug.LogFormat("Deleting '{0}'", activeObject.name); 
        GameObject.Destroy(activeObject);
        InputManager.Instance.activeGameObject = InputManager.Instance.selectedGameObject;
        DeleteButton.interactable = false;
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), InputManager.Instance.activeGameObject?.name, myRectStyle);
    }
}