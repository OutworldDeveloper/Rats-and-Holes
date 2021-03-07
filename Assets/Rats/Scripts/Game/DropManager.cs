using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{

    [SerializeField]
    private DropHearth dropPrefabHeart;

    [SerializeField]
    private HatDrop dropPrefabHat;

    [SerializeField]
    private int heartChance = 100;

    [SerializeField]
    private int hatChance = 5000;

    private int currentHeartChances;

    private void Start()
    {
        currentHeartChances = heartChance;
    }

    private void OnEnable()
    {
        Rat.OnRatDied += Rat_OnRatDied;
    }

    private void OnDisable()
    {
        Rat.OnRatDied -= Rat_OnRatDied;
    }

    private void Rat_OnRatDied(Rat rat)
    {
        Drop(rat.transform.position);
    }

    public void Drop(Vector3 position)
    {
        //Heart
        /*
        if(Random.Range(0, currentHeartChances + 1) <= 0)
        {
            currentHeartChances = heartChance;
            Instantiate(dropPrefabHeart, position, Quaternion.identity);
        }
        else
        {
            currentHeartChances--;
        }
        */
        //Hat
        if(Random.Range(0, hatChance + 1) <= 0)
        {
            Instantiate(dropPrefabHat, position, Quaternion.identity);
        }
    }
    
}