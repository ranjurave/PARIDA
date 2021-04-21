using UnityEngine;

public enum Styles {
    NONE,
    ALL,
    BOHEMIAN,
    MID_CENTURY,
    MODERN,
    MINIMALISTIC
}

public enum Category {
    NONE,
    COUCH,
    CHAIR,
    TV,
    FIREPLACE,
    FLOORLAMP,
    PLANTS,
    COFFEETABLE
}

public class ObjectPropertySet : MonoBehaviour {
    public string objName;
    public Styles style;
    public Sprite sprite;
    public TextureSet texSet;
    public ObjectMaterialSet[] materialSet;
}
