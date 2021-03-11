using UnityEngine;

public enum Styles {
    NONE,
    BOHEMIAN,
    MID_CENTURY,
    MODERN,
    MINIMALISTIC
}

public class ObjectPropertySet : MonoBehaviour {
    public string objName;
    public Styles style;
    public Sprite sprite;
}
