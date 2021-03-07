using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldRat : Rat
{

    [SerializeField]
    private Movement defaultMovement;

    [SerializeField]
    private Movement lowHealthMovement;

    [SerializeField]
    private int healthThreshold = 1;

    private bool isMovementChanged;

    public UnityEvent OnMovementChanged;

    protected override void Awake()
    {
        base.Awake();
        lowHealthMovement.enabled = false;
    }

    protected override void HealthChanged(int health)
    {
        base.HealthChanged(health);
        if (isMovementChanged)
        {
            return;
        }
        else
        {
            if (health <= healthThreshold)
            {
                isMovementChanged = true;
                defaultMovement.enabled = false;
                lowHealthMovement.enabled = true;
                OnMovementChanged.Invoke();
            }
        }
    }

}