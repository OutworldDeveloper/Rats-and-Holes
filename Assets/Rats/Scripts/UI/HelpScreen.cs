using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{

    [SerializeField]
    private Text ui_helpText;

    [SerializeField]
    [TextArea(2,5)]
    private string defaultHelpText;

    [SerializeField]
    [TextArea(2, 5)]
    private string mobileHelpText;

    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            ui_helpText.text = mobileHelpText;
        }
        else
        {
            ui_helpText.text = defaultHelpText;
        }
    }

}