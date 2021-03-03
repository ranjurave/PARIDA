﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToSpawn : MonoBehaviour {
    //public static InputManager ipManager;
    public MenuManager mm;
    public GameObject selectedObject;
    public Button btn;

    void Start() {
        btn.onClick.AddListener(AssignObject);
    }

    void AssignObject() {
        InputManager.Instance.selectedGameObject = selectedObject;
        mm.ObjectSelected();
    }

    //private void OnGUI()
    //{
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 25;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 500), new Vector2(200, 200)), debug, myRectStyle);
    //}
}
