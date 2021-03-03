using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreObjectSpawn : MonoBehaviour
{ 
    public MenuManager mm;
    private GameObject selectedObject;
    //public Button btn;

    public GameObject btn;
    public Transform buttonHolder;
    Texture[] imgTexture;

    // Start is called before the first frame update
    void Start() {
        imgTexture = Resources.LoadAll<Texture>("MoreFurnitureImage");
        foreach (Texture img in imgTexture) {
            GameObject furnitureButton = Instantiate(btn as GameObject);
            furnitureButton.transform.SetParent(buttonHolder);
            furnitureButton.GetComponent<RawImage>().texture = img;
            string textureName = img.name;
            furnitureButton.GetComponent<Button>().onClick.AddListener(() => AssignObject(textureName));
        }
    }

    void AssignObject(string furnitureName) {
        //debugstring = furnitureName;
        //string buttonName = 
        selectedObject = GameObject.Find(furnitureName);
        mm.ObjectSelected();
        InputManager.Instance.selectedGameObject = selectedObject;
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 25;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(400, 100)), selectedObject.name, myRectStyle);
    }
}
