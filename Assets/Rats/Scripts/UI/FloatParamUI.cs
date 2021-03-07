using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatParamUI : MonoBehaviour
{

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text textName;

    [SerializeField]
    private Text textValue;

    private FloatParameter targetFloatParameter;

    private bool isReady;

    public void Setup(FloatParameter floatParameter)
    {
        targetFloatParameter = floatParameter;

        slider.minValue = floatParameter.GetMinValue();
        slider.maxValue = floatParameter.GetMaxValue();

        slider.wholeNumbers = floatParameter.WholeValue();

        if (floatParameter.ReversedValue())
        {
            slider.value = floatParameter.GetMaxValue() - floatParameter.GetCustomValue();
            textValue.text = (floatParameter.GetMaxValue() - floatParameter.GetCustomValue()).ToString();
        }
        else
        {
            slider.value = floatParameter.GetCustomValue();
            textValue.text = floatParameter.GetCustomValue().ToString();
        }

        textName.text = floatParameter.GetDisplayName();

        isReady = true;
    }

    public void ChangeParameter(float value)
    {
        if (!isReady)return;
        if(targetFloatParameter.ReversedValue())
        {
            targetFloatParameter.SetCustomValue(targetFloatParameter.GetMaxValue() - value);
            textValue.text = value.ToString();
        }
        else
        {
            targetFloatParameter.SetCustomValue(value);
            textValue.text = value.ToString();
        }
    }

}