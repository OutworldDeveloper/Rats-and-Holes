using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RatAnimator : ActorAnimator
{

    private SpriteRenderer spriteRenderer;

    public void ChangeSpriteDirection(bool isFacingRight)
    {
        spriteRenderer.flipX = isFacingRight;
    }

    public void ChangeSpeed(float newSpeed)
    {
        animator.SetFloat("Speed", newSpeed / 2f);
    }

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


}