using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRat : Rat
{

    [SerializeField]
    private Movement baseMovement;

    protected override void Death()
    {
        base.Death();
        baseMovement.enabled = false;
    }

}