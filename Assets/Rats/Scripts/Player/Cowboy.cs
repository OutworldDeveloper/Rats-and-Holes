using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Cowboy : MonoBehaviour
{

    [SerializeField]
    private CowboyClothes cowboyClothes;

    [SerializeField]
    private GameObject muzzleFlash;

    private float timer;

    private bool isFacingRight;

    public void Shoot()
    {
        muzzleFlash.SetActive(true);
        timer = Time.time + 0.1f;
    }

    private void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        //cowboyClothes.ShowFront(!(direction.x > 0));
        TurnRight((direction.x > 0));

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if ((direction.x > 0))
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        }

        cowboyClothes.GetHandTransform().rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Time.time >= timer)
        {
            muzzleFlash.SetActive(false);
        }
    }

    private void TurnRight(bool b)
    {
        cowboyClothes.ShowFront(!b);
        if (!isFacingRight == b)
        {
            if (b == true)
            {
                cowboyClothes.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                isFacingRight = true;
            }
            else
            {
                cowboyClothes.transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                isFacingRight = false;
            }
        }
    }

}