using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(TransformController))]
public abstract class Rat : Actor
{

    public delegate void RatDied(Rat rat);

    public static event RatDied OnRatDied;

    public string displayName;
    public FloatParameter spawnTime;
    public FloatParameter spawnChance;
    public BoolParameter spawnable;

    public FloatParameter speedMultiplier;

    protected BoxCollider2D boxCollider2D;
    protected TransformController transformController;

    protected float spawnDifficulty;
    protected bool isStunned;


    public bool IsStunned()
    {
        return isStunned;
    }

    public string GetDisplayName()
    {
        return displayName;
    }

    public void Stun(bool stun)
    {
        transformController.Stop(stun);
        boxCollider2D.enabled = !stun;
        isStunned = stun;
    }

    public void SetSpeed(float speed)
    {
        transformController.SetSpeed(speed);
    }

    protected override void Awake()
    {
        base.Awake();
        boxCollider2D = GetComponent<BoxCollider2D>();
        transformController = GetComponent<TransformController>();
    }

    protected virtual void Start()
    {
        spawnDifficulty = GameManager.instance.GetCurrentDifficulty();
        ResetSpeed();
    }

    protected override void Death()
    {
        base.Death();
        boxCollider2D.enabled = false;
        if (OnRatDied != null) OnRatDied(this);
        foreach (var item in GetComponents<Movement>())
        {
            item.enabled = false;
        }
    }

    public void ResetSpeed()
    {
        transformController.SetSpeed(speedMultiplier.GetValue() * spawnDifficulty);
    }

}