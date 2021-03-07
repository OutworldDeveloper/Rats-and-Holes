using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BoolParameter", menuName = "GameParameters/BoolParameter")]
public class BoolParameter : GameParameter<bool>
{

    public override void SetCustomValue(bool value)
    {
        PlayerPrefs.SetInt(this.name, (value ? 1 : 0));
    }

    public override bool GetValue()
    {
        if (PlayerProfile.playCustoms && PlayerPrefs.HasKey(this.name))
        {
            return PlayerPrefs.GetInt(this.name) != 0;
        }
        return defaultValue;
    }

    public override bool GetCustomValue()
    {
        if (PlayerPrefs.HasKey(this.name))
        {
            return PlayerPrefs.GetInt(this.name) != 0;
        }
        return defaultValue;
    }

}