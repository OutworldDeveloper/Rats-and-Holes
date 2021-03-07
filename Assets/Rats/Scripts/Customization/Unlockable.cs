using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unlockable", menuName = "Shop/Unlockable")]
public class Unlockable : ShopItem
{

    [SerializeField]
    private UnlockableItem unlockable;

    public override bool CanBuy()
    {
        return !unlockable.isUnlocked();
    }

    protected override void OnBuy()
    {
        unlockable.Unlock();
    }

}