using UnityEngine;
public enum TextureSet {
    NONE,
    TV1,
    TV2,
    TV3,
    COUCHMINIMAL,
    COUCHMODERN1,
    COUCHMODERN2,
    COUCHMODERN3,
    COUCHMODERN4,
    COFFEETABLE1,
    TABLE1,
    TABLE2,
    TABLE3,
    LIBRARY1,
    LIBRARY2,
    LIBRARY3
}

public class ObjectMaterialSet : MonoBehaviour {
    public Sprite matImage;
    public TextureSet texSet;
    public Material materialOption;
}
