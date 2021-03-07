using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class HealthComponent : MonoBehaviour
{

    [SerializeField]
    private int startHealth = 1;

    private int health;

    public IntEvent OnHealthChanged;

    public void ApplyDamage(int damage)
    {
        health -= damage;
        OnHealthChanged.Invoke(health);
    }

    public void Heal(int heal)
    {
        health += heal;
        OnHealthChanged.Invoke(health);
    }

    private void Awake()
    {
        health = startHealth;
    }

}