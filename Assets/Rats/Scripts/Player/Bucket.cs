using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : Actor
{

    private Rat targetRat;
    private float breakTime;

    public void CatchRat(Rat rat)
    {
        transform.position = rat.transform.position;
        targetRat = rat;
       // targetRat.gameObject.SetActive(false);
        targetRat.GetComponentInChildren<SpriteRenderer>().enabled = false;
        targetRat.Stun(true);
        breakTime = Time.time + 10f;
    }

    private void ReliseRat()
    {
        //targetRat.gameObject.SetActive(true);
        targetRat.GetComponentInChildren<SpriteRenderer>().enabled = true;
        targetRat.Stun(false);
    }

    protected override void Death()
    {
        base.Death();
        ReliseRat();
    }

    private void Update()
    {
        if (isDead) return;
        if (Time.time >= breakTime) Death();
    }

}