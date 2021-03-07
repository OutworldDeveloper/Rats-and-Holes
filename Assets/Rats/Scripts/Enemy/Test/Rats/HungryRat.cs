using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DestianationMovement))]
public class HungryRat : Rat
{

    public UnityEvent OnTargetEaten;

    private DestianationMovement destianationMovement;
    private Rat target;
    private bool hasEaten;
    /*
    protected override void Awake()
    {
        base.Awake();
        destianationMovement = GetComponent<DestianationMovement>();
    }

    protected override void Start()
    {
        base.Start();
        destianationMovement.OnDestinationReached += DestianationMovement_OnDestinationReached;
        destianationMovement.SetDestination(new Vector2(-20f, transform.position.y));
    }

    private void DestianationMovement_OnDestinationReached(object sender, System.EventArgs e)
    {
        if (hasEaten) return;
        SelectMovePosition();
    }

    private void Update()
    {
        if (target == null)
        {
            FindTraget();

        }
    }

    private void SelectMovePosition()
    {
        Vector3 movePosition = new Vector3(0, 0, 0);
        movePosition.x = Random.Range(0, 5);
        movePosition.y = Random.Range(-3, 3);
        destianationMovement.SetDestination(movePosition);
    }

    protected override void Death()
    {
        base.Death();
        if (hasEaten && target != null)
        {
            target.transform.position = this.transform.position;
            target.GetComponentInChildren<SpriteRenderer>().enabled = true;
            target.Stun(false);
        }

    }

    private void EatTarget()
    {
        hasEaten = true;
        target.GetComponentInChildren<SpriteRenderer>().enabled = false;
        target.Stun(true);
        OnTargetEaten.Invoke();
        destianationMovement.SetDestination(new Vector2(-20f , transform.position.y));
    }

    private void ClearTarget()
    {
        target = null;
    }

    /*
    private void FindTraget()
    {
        Rat potentialTarget = null;
        foreach (var item in FindObjectsOfType<Rat>())
        {
            if(item != this && !(item is HungryRat) && !(item is BannerRat) && !item.IsDead() && !item.IsStunned())
            {
                if (potentialTarget == null)
                    potentialTarget = item;
                else
                {
                    if (Vector3.Distance(this.transform.position, potentialTarget.transform.position) < Vector3.Distance(this.transform.position, item.transform.position))
                        potentialTarget = item;
                }
            }
        }
        if(potentialTarget != null)
        {
            target = potentialTarget;
   
        }
    }
    */

        /*
    private Rat FindTraget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            Rat item = hit.transform.GetComponent<Rat>();
            if (item != this && !(item is HungryRat) && !(item is BannerRat) && !item.IsDead() && !item.IsStunned())
            {
                if (potentialTarget == null)
                    potentialTarget = item;
                else
                {
                    if (Vector3.Distance(this.transform.position, potentialTarget.transform.position) < Vector3.Distance(this.transform.position, item.transform.position))
                        potentialTarget = item;
                }
            }
        }

        Rat potentialTarget = null;
        foreach (var item in FindObjectsOfType<Rat>())
        {
            if (item != this && !(item is HungryRat) && !(item is BannerRat) && !item.IsDead() && !item.IsStunned())
            {
                if (potentialTarget == null)
                    potentialTarget = item;
                else
                {
                    if (Vector3.Distance(this.transform.position, potentialTarget.transform.position) < Vector3.Distance(this.transform.position, item.transform.position))
                        potentialTarget = item;
                }
            }
        }
        if (potentialTarget != null)
        {
            target = potentialTarget;

        }
    }
    */

}