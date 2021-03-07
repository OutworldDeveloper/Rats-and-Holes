using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CodeMonkey.Utils;

[RequireComponent(typeof(LineMovement))]
public class DodgeRat : Rat
{

    public UnityEvent OnDodge;

    [SerializeField]
    private float dodgeRadius = 1.5f;

    [SerializeField]
    private float minAfraidTime = 2.5f;

    [SerializeField]
    private float maxAfraidTime = 3.5f;

    private LineMovement lineMovement;

    private enum DodgeRatState
    {
        attack,
        dodge,
        afraid
    }

    private DodgeRatState currentState;

    private float dodgeEndTime;
    private float afraidEndTime;

    public override void ApplyDamage(int damage, DamageType damageType)
    {
        if(currentState == DodgeRatState.attack && damageType.isDodgeable)
        {
            Dodge();
            return;
        }
        base.ApplyDamage(damage, damageType);
    }

    protected override void Awake()
    {
        base.Awake();
        lineMovement = GetComponent<LineMovement>();
    }

    private void Update()
    {
        if (isDead) return;
        if(currentState == DodgeRatState.attack)
        {
            return;
        }
        else if (currentState == DodgeRatState.dodge)
        {
            if(Time.time >= dodgeEndTime)
            {
                currentState = DodgeRatState.afraid;
                afraidEndTime = Time.time + Random.Range(minAfraidTime, maxAfraidTime);
                lineMovement.enabled = true;
            }
        }
        else if (currentState == DodgeRatState.afraid)
        {
            if (Time.time >= afraidEndTime || transform.position.x >= 7f)
            {
                currentState = DodgeRatState.attack;
                lineMovement.isMovingBack = false;
            }
        }
    }

    private void Dodge()
    {
        OnDodge.Invoke();
        currentState = DodgeRatState.dodge;
        dodgeEndTime = Time.time + 0.5f;
        lineMovement.isMovingBack = true;
        lineMovement.enabled = false;
    }

}