using UnityEngine;

[CreateAssetMenu(fileName = "New Object Database", menuName = "Custom/ObjectDatabase")]
public class ObjectDatabase : ScriptableObject {
    public ObjectPropertySet[] couches;
    public ObjectPropertySet[] tables;
    public ObjectPropertySet[] chairs;
}