using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameParameterBase : UnlockableItem
{

    public static List<GameParameterBase> GetGameParameters()
    {
        List<GameParameterBase> gameParameters = new List<GameParameterBase>();
        foreach (var item in Resources.LoadAll<GameParameterBase>("GameSettings/"))
        {
            if (!item.isHidden) gameParameters.Add(item);
        }
        return gameParameters;
    }

    [Header("Settings")]
    [SerializeField]
    private string displayName;

    [SerializeField]
    private string group;

    [SerializeField]
    private bool isHidden;

    public string GetDisplayName()
    {
        return displayName;
    }

    public string GetGroup()
    {
        return group;
    }

    public abstract void ResetValue();

}

public abstract class GameParameter<T> : GameParameterBase
{

    [Header("Value")]
    [SerializeField]
    protected T defaultValue;
    public abstract void SetCustomValue(T value);

    public abstract T GetValue();

    public abstract T GetCustomValue();
    
    public override void ResetValue()
    {
        SetCustomValue(defaultValue);
    }
    
}