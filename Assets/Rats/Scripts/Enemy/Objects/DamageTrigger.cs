using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{

    public bool isWorking = true;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private DamageType damageType;

    [SerializeField]
    private bool destroy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isWorking)
            return;
        if (collision.GetComponent<Actor>())
        {
            if (collision.GetComponent<Actor>().IsDead())
            {
                return;
            }
            else
            {
                collision.GetComponent<Actor>().ApplyDamage(damage, damageType);
                if (destroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}