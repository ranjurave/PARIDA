using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class MaterialToApply : MonoBehaviour {
    public static MaterialToApply Instance;
    public Material pickedMaterial { get; set; }
    public Button btn;
    public ObjectPropertySet toChangeObject { get; set; }
    //private string debugstring;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        btn.onClick.AddListener(AssignMaterial);
    }

    void AssignMaterial() {
        List<MeshFilter> meshObjects = toChangeObject.transform.GetComponentsInChildren<MeshFilter>().ToList();
        meshObjects.RemoveAt(0); // not to apply material for the selection hilight mesh
        foreach (MeshFilter mesh in meshObjects) {
            mesh.GetComponent<Renderer>().material = pickedMaterial;
        }
        MenuManager.Instance.BackButton();
    }

    //private void OnGUI() {
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 500), new Vector2(200, 200)), debugstring, myRectStyle);
    //}
}
