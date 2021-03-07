using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingRat : Rat
{

    [SerializeField]
    private float teleportDelay = 0.5f;

    private float nextTeleportTime;

    private void Update()
    {
        if(Time.time >= nextTeleportTime)
        {
            nextTeleportTime = Time.time + teleportDelay;
            Teleport();
        }
    }

    private void Teleport()
    {
        //transform.position = transform.position - transform.right * 2f;
    }

    public override void ApplyDamage(int damage, DamageType damageType)
    {
        base.ApplyDamage(damage, damageType);
        if(damageType.canBeReturned)
        {
            GameManager.instance.GetPlayer().SetDamage(damage);
        }
    }

}