using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    private Button btn;
    public GameObject nextPanel;

    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PanelSwitch);
    }

    public void PanelSwitch() {;
        nextPanel.SetActive(true);
    }
}
