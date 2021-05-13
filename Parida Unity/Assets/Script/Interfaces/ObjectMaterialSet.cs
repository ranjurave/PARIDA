using UnityEngine;
public enum TextureSet {
    NONE,
    TV1,
    TV2,
    TV3,
    FIREPLACE1,
    FIREPLACE2,
    BOOKSHELF1,
    BOOKSHELF2,
    BOOKSHELF3,
    CHAIR1,
    CHAIR2,
    CHAIR3,
    CHAIR4,
    CHAIR5,
    COUCHMINIMAL,
    COUCHMODERN1,
    COUCHMODERN2,
    COUCHMODERN3,
    COUCHMODERN4,
    COFFEETABLE1,
    COFFEETABLE2,
    COFFEETABLE3,
    COFFEETABLE4,
    FLOORLAMP1,
    FLOORLAMP2,
    FLOORLAMP3,
    FLOORLAMP4
}

public class ObjectMaterialSet : MonoBehaviour {
    public Sprite matImage;
    public TextureSet texSet;
    public Material materialOption;
}
