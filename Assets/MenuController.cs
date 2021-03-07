using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private UIController controller;

    private void Start()
    {
        exitButton.SetActive(SystemInfo.deviceType == DeviceType.Desktop);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            controller.OpenLastScreen();
        }
    }
}
