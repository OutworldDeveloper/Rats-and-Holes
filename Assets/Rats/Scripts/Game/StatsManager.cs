using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    public int ratsKilled { get; private set; }
    public float deadeyeTimer { get; private set; }

    public int GetEarnedCoins()
    {
        return Mathf.FloorToInt(GameManager.instance.GetCurrentTime() / 50);
    }

    private void Start()
    {
        Rat.OnRatDied += Rat_OnRatDied;
    }

    private void OnDestroy()
    {
        Rat.OnRatDied -= Rat_OnRatDied;
    }

    private void Update()
    {
        if (GameManager.instance.GetPlayer().isDeadeye)
        {
            deadeyeTimer += Time.deltaTime;
        }
    }

    private void Rat_OnRatDied(Rat rat)
    {
        ratsKilled++;
    }

}