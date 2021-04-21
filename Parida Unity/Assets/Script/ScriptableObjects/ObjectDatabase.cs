using UnityEngine;

[CreateAssetMenu(fileName = "New Object Database", menuName = "Custom/ObjectDatabase")]
public class ObjectDatabase : ScriptableObject {
    public ObjectPropertySet[] couches;
    public ObjectPropertySet[] chairs;
    public ObjectPropertySet[] tvs;
    public ObjectPropertySet[] coffeeTable;
    public ObjectPropertySet[] firePlace;
    public ObjectPropertySet[] floorLamp;
}