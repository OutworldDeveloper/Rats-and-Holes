using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRatAnimator : RatAnimator
{
   
    public void ShieldBroke()
    {
        animator.SetBool("IsShieldBroken", true);
    }

}