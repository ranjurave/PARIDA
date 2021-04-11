using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    public Button ScreenShotButton;
    public int shotIndex;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        ScreenShotButton.onClick.AddListener(TakeScreenShot);
    }

    void TakeScreenShot()
    {
        
        string fileName = "Screenshot" + shotIndex + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave,2);
        shotIndex++;
    }
    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 40;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 500), new Vector2(200, 200)), shotIndex.ToString(), myRectStyle);
    }
}
