using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryRatAnimator : RatAnimator
{
   
    public void Eat()
    {
        animator.SetTrigger("Eat");
    }

}