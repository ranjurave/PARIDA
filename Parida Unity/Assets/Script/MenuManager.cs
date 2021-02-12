using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour {
    public bool debug;
    private Button btn;
    public GameObject selectedFocus;
    public GameObject RootPanel;
    public GameObject roomSelection;
    public GameObject styleSelection;
    public GameObject focusObjectSelection;
    public GameObject focusObjectTypeSelection;

    void Start() {
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenApp);
    }

    public void OpenApp() {
        InputManager.Instance.selectedGameObject = selectedFocus;
        RootPanel.SetActive(false);

    }
    public void TestMethod() {
        InputManager.Instance.selectedGameObject = selectedFocus;
        roomSelection.SetActive(false);
        styleSelection.SetActive(true);
    }
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
    //public void OpenApp() {
    //    InputManager.Instance.selectedGameObject = selectedFocus;
    //    RootPanel.SetActive(false);
    //}
}
