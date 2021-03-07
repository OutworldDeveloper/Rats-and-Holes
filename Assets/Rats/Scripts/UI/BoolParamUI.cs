using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolParamUI : MonoBehaviour
{

    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private Text textName;

    private BoolParameter targetBoolParameter;

    private bool isReady;

    public void Setup(BoolParameter boolParameter)
    {
        targetBoolParameter = boolParameter;

        toggle.isOn = boolParameter.GetCustomValue();

        textName.text = boolParameter.GetDisplayName();

        isReady = true;
    }

    public void ChangeParameter(bool value)
    {
        if (!isReady) return;
        targetBoolParameter.SetCustomValue(value);
    }

}