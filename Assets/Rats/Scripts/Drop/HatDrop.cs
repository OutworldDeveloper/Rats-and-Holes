using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatDrop : Drop
{

    [SerializeField]
    private Clothes hat;

    public override void Take(Player player)
    {
        hat.Unlock();
        hat.slot.SetClothes(hat);
        base.Take(player);
    }

}