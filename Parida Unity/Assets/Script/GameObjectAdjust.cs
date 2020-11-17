using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameObjectAdjust : MonoBehaviour
{
    private Button btn;
    public GameObject setGameObject;
    private string debugString;
    // Start is called before the first frame update
    void Start()
    {
        debugString = "start";
        btn = GetComponent<Button>();

        btn.onClick.AddListener(DeleteGameObject);
    }

    // Update is called once per frame
    void DeleteGameObject()
    {
        debugString = "Button press" ;
        setGameObject.SetActive(false);
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        //activeGameObject = objectHit.collider.gameObject;
        GUI.Box(new Rect(new Vector2(100, 300), new Vector2(200, 200)), debugString, myRectStyle);
    }
}
