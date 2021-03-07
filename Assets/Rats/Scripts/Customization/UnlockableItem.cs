using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnlockableItem : ScriptableObject
{

    [SerializeField]
    protected bool isUnlockedByDefault;

    public bool isUnlocked()
    {
        if (isUnlockedByDefault)
        {
            return true;
        }
        else
        {
            return PlayerPrefs.GetInt(this.name + "unlocked") == 1;
        }
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt(this.name + "unlocked", 1);
    }

}