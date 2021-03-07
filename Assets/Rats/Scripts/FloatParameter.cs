using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New FloatParameter", menuName = "GameParameters/FloatParameter")]
public class FloatParameter : GameParameter<float>
{

    [SerializeField]
    private float minValue, maxValue;

    [SerializeField]
    private bool wholeValue;

    [SerializeField]
    private bool reversedValue;

    public bool ReversedValue()
    {
        return reversedValue;
    }

    public bool WholeValue()
    {
        return wholeValue;
    }

    public float GetMinValue()
    {
        return minValue;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    public override void SetCustomValue(float value)
    {
        PlayerPrefs.SetFloat(this.name, value);
    }

    public override float GetValue()
    {
        if (PlayerProfile.playCustoms && PlayerPrefs.HasKey(this.name))
        {
            return PlayerPrefs.GetFloat(this.name);
        }
        return defaultValue;
    }

    public override float GetCustomValue()
    {
        if (PlayerPrefs.HasKey(this.name))
        {
            return PlayerPrefs.GetFloat(this.name);
        }
        return defaultValue;
    }
}