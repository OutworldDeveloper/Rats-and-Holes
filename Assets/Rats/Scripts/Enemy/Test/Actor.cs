using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthComponent))]
public class Actor : MonoBehaviour, IDamageable
{

    public delegate void ActorDeath(Actor actor);
    public event ActorDeath OnActorDeath;

    public bool isInvencible;

    [SerializeField]
    private float destroyDelay = 1f;

    private HealthComponent healthComponent;

    protected bool isDead;

    public UnityEvent OnDeath;

    public bool IsDead()
    {
        return isDead;
    }

    public virtual void ApplyDamage(int damage, DamageType damageType)
    {
        if (isInvencible)
        {
            return;
        }
        else
        {
            healthComponent.ApplyDamage(damage);
        }
    }

    protected virtual void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnHealthChanged.AddListener(HealthChanged);
    }

    protected virtual void Death()
    {
        isDead = true;
        OnDeath.Invoke();
        if (OnActorDeath != null) OnActorDeath(this);
        Destroy(this.gameObject, destroyDelay);
    }

    protected virtual void HealthChanged(int health)
    {
        if (isDead)
        {
            return;
        }
        else
        {
            if (health <= 0)
            {
                Death();
            }
        }
    }

}