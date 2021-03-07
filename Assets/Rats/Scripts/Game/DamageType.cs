using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DamageType", menuName = "DamageType")]
public class DamageType : ScriptableObject
{

    public string displayName;
    public bool isDodgeable;
    public bool canBeReturned;

}