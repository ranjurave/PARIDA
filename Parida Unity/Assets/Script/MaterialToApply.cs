using UnityEngine;
using UnityEngine.UI;

public class MaterialToApply : MonoBehaviour {
    public static MaterialToApply Instance;
    public Material pickedMaterial { get; set; }
    public Button btn;
    public ObjectMaterialSet selectedMaterial { get; set; }

    //private string debugstring;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        btn.onClick.AddListener(AssignMaterial);
    }

    void AssignMaterial() {
        // TODO apply material
        ObjectPropertySet furniture = InputManager.Instance.activeGameObject;
        furniture.transform.GetChild(2).GetComponent<Renderer>().material = pickedMaterial;
        MenuManager.Instance.BackButton();
    }

    //private void OnGUI() {
    //    GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
    //    myRectStyle.fontSize = 40;
    //    myRectStyle.normal.textColor = Color.red;
    //    GUI.Box(new Rect(new Vector2(100, 500), new Vector2(200, 200)), debugstring, myRectStyle);
    //}
}
