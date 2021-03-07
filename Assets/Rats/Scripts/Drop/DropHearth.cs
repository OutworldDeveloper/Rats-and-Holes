
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHearth : Drop
{

    [SerializeField]
    private int healAmount = 1;

    public override void Take(Player player)
    {
        player.AddHealth(healAmount);
        base.Take(player);
    }

}