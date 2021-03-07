using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerNew : Actor
{

    [SerializeField]
    private FloatParameter liveTime;

    private float deathTime;

    private void Start()
    {
        deathTime = Time.time + liveTime.GetValue();
    }

    private void Update()
    {
        if(Time.time >= deathTime && !isDead)
        {
            Death();
        }
    }

}