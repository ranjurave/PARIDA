using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour {
    //public bool debug;
    //private Button btn;
    public GameObject selectedFocus;
    private GameObject previousPanel;
    private GameObject curentPanel;
    public GameObject onScreenUI;
    public GameObject roomSelection;
    public GameObject styleSelection;
    public GameObject focusObjectSelection;
    public GameObject focusObjectTypeSelection;

    void Start() {
        roomSelection.SetActive(true);
        styleSelection.SetActive(false);
        focusObjectTypeSelection.SetActive(false);
        focusObjectSelection.SetActive(false);
        //btn = GetComponent<Button>();
        //btn.onClick.AddListener(OpenApp);
    }

    //public void OpenApp() {
    //    rootPanel.SetActive(false);
    //}

    public void StyleSelection() {
        previousPanel = roomSelection;
        curentPanel = styleSelection;
        previousPanel.SetActive(false);
        curentPanel.SetActive(true);
    }
    public void FocusObjectTypeSelection() {
        previousPanel = curentPanel;
        curentPanel = focusObjectTypeSelection;
        previousPanel.SetActive(false);
        curentPanel.SetActive(true);
    }
    public void FocusObjectSelection() {
        previousPanel = curentPanel;
        curentPanel = focusObjectSelection;
        previousPanel.SetActive(false);
        curentPanel.SetActive(true);
    }
    public void ObjectSelected() {
        previousPanel = curentPanel;
        curentPanel = onScreenUI;
        previousPanel.SetActive(false);
        curentPanel.SetActive(true);
    }
    public void BackButton() {
        previousPanel = onScreenUI;
        curentPanel = previousPanel;
        previousPanel.SetActive(false);
        curentPanel.SetActive(true);
    }
}
