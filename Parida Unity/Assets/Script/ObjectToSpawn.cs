using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToSpawn : MonoBehaviour {
    public static MenuManager mM;
    public GameObject selectedObject;
    public Button btn;

    // Start is called before the first frame update
    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AssignObject);
    }

    void AssignObject() {
        mM.selectedFocus = selectedObject;
        //mM.ObjectSelected();
    }
}
