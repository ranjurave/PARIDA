using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEstimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(Shader.GetGlobalFloat("_GlobalLightEstimation"));
    //}

    private void OnGUI() {
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(200, 200)), Shader.GetGlobalFloat("_GlobalLightEstimation").ToString());
    }
}
