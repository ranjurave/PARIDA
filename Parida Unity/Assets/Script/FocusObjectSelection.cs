using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FocusObjectSelection : MonoBehaviour {
    public bool debug;
    private Button btn;
    public GameObject selectedFocus;
    public GameObject RootPanel;

    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenApp);
    }

    public void OpenApp() {
        InputManager.Instance.selectedGameObject = selectedFocus;
        RootPanel.SetActive(false);
    }
}
