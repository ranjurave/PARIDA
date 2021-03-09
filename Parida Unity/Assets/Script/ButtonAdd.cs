using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAdd : MonoBehaviour
{
    public GameObject btn;
    public Transform buttonHolder;
    Texture[] imgTexture;
    GameObject[] objToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        imgTexture = Resources.LoadAll<Texture>("Image");
        objToSpawn = Resources.LoadAll<GameObject>("Furniture");

        //foreach(GameObject gObj in objToSpawn) {
        //    GameObject filterButton = Instantiate(btn as GameObject);
        //    filterButton.transform.SetParent(buttonHolder);
        //}

        foreach(Texture img in imgTexture) {
            GameObject filterButton = Instantiate (btn as GameObject);
            filterButton.transform.SetParent(buttonHolder);
            filterButton.GetComponent<RawImage>().texture = img;
            // TODO: Remember this thingy.
            //filterButton.GetComponent<DynamicButton>.get
            //filterButton.GetComponent<GameObject>().gameObject = objToSpawn[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
