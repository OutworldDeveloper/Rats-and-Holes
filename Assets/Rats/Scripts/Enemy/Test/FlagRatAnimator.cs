using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagRatAnimator : RatAnimator
{
    
    public virtual void BannerPlaced()
    {
        animator.SetBool("IsBannerPlaced", true);
    }

}