using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessAura : MonoBehaviour
{

    public bool isWorking;

    [SerializeField]
    private FloatParameter speed;

    private List<Rat> rats = new List<Rat>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (!isWorking) return;
        Rat target = collision.gameObject.GetComponent<Rat>();
        if(target != null && !target.IsDead())
        {
            rats.Add(target);
        }
        */
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isWorking) return;
        Rat target = collision.gameObject.GetComponent<Rat>();
        if (target != null && !target.IsDead())
        {
            target.SetSpeed(speed.GetValue());
        }
    }

    private void Update()
    {
        /*
        if (!isWorking) return;
        if (rats.Count > 0)
        {
            foreach (var item in rats)
            {
                item.SetSpeed(speed.GetValue());
            }
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isWorking) return;
        Rat target = collision.gameObject.GetComponent<Rat>();
        if (target != null && !target.IsDead())
        {
            rats.Remove(target);
            target.ResetSpeed();
        }
    }

}