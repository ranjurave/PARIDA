using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicButton : MonoBehaviour
{
    public ObjectPropertySet toSpawnObject;
    public Button objectsButton;
    // Start is called before the first frame update
    void Start()
    {
        objectsButton.onClick.AddListener(SetSpawnObject);
    }

    void SetSpawnObject() {
        InputManager.Instance.selectedGameObject = toSpawnObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
