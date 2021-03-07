using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ActorAnimator : MonoBehaviour
{

    protected Animator animator;

    public virtual void RatDied()
    {
        animator.SetBool("IsDead", true);
    }

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

}