using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicButton : MonoBehaviour {
    public Button objectsButton;
    public MenuManager mm { get; set; }
    public ObjectPropertySet toSpawnObject { get; set; }

    // Start is called before the first frame update
    void Start() {
        objectsButton.onClick.AddListener(SetSpawnObject);
    }

    void SetSpawnObject() {
        InputManager.Instance.selectedGameObject = toSpawnObject;
        mm.ObjectSelected();
    }
}