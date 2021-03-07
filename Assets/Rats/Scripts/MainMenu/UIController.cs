using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private UIPanel startPanel;

    private List<UIPanel> panels = new List<UIPanel>();

    private UIPanel currentPanel;
    private UIPanel lastPanel;

    public void OpenPanel(UIPanel targetPanel)
    {
        if(currentPanel != null)
        {
            lastPanel = currentPanel;
            currentPanel.ClosePanel();
        }
        currentPanel = targetPanel;
        currentPanel.StartPanel();
    }

    public void OpenLastScreen()
    {
        if(lastPanel != null)
        {
            OpenPanel(lastPanel);
        }
    }

    private void Awake()
    {
        foreach (var item in GetComponentsInChildren<UIPanel>(true))
        {
            panels.Add(item);
            item.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        OpenPanel(startPanel);
    }

}