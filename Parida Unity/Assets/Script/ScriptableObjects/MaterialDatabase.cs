using UnityEngine;

[CreateAssetMenu(fileName = "New Material Database", menuName = "Custom/MaterialDatabase")]
public class MaterialDatabase : ScriptableObject {
    public ObjectMaterialSet[] couche1;
    public ObjectMaterialSet[] couche2;
    public ObjectMaterialSet[] couche3;
    public ObjectMaterialSet[] couchMinimal1;
    public ObjectMaterialSet[] table1;
    public ObjectMaterialSet[] table2;
    public ObjectMaterialSet[] table3;
    public ObjectMaterialSet[] library1; 
    public ObjectMaterialSet[] library2;
    public ObjectMaterialSet[] library3;
}
