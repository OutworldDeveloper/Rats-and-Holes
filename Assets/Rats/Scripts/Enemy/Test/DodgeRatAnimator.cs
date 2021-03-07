using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRatAnimator : RatAnimator
{
   
    public void Dodge()
    {
        animator.SetTrigger("Dodge");
    }

}