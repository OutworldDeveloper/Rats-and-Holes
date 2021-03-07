using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsSpawner : MonoBehaviour
{

    [SerializeField]
    private Rat defaultRat;

    private List<RatForSpawn> ratsForSpawn = new List<RatForSpawn>();

    public Rat SpawnRat(Vector3 position)
    {
        Rat rat = RandomRat();
        if(rat != null)
        {
            return Instantiate(rat, position, Quaternion.identity);
        }
        else
        {
            return Instantiate(defaultRat, position, Quaternion.identity);
        }
    }

    private Rat RandomRat()
    {
        RatForSpawn rfs = new RatForSpawn();
        foreach (var item in ratsForSpawn)
        {
            if (GameManager.instance.GetCurrentTime() >= item.ratPrefab.spawnTime.GetValue())
            {
                if ((int)Random.Range(0, item.currentChance + 1) == 0)
                {
                    item.ResetChance();
                    if (rfs.ratPrefab == null)
                    {
                        rfs = item;
                    }
                    else
                    {
                        if (item.ratPrefab.spawnChance.GetValue() > rfs.ratPrefab.spawnChance.GetValue())
                        {
                            rfs = item;
                        }
                    }
                }
                else
                {
                    item.DecreaseChance();
                }
            }
        }
        return rfs.ratPrefab;
    }

    private void Awake()
    {
        foreach (var item in Resources.LoadAll<Rat>("RatsPrefabs/"))
        {
            if (item.spawnable.GetValue())
            {
                RatForSpawn rfs = new RatForSpawn();
                rfs.ratPrefab = item;
                rfs.ResetChance();
                ratsForSpawn.Add(rfs);
            }
        }
    }

}

[System.Serializable]
public class RatForSpawn
{

    public Rat ratPrefab;
    public float currentChance;

    public void ResetChance()
    {
        currentChance = ratPrefab.spawnChance.GetValue();
    }

    public void DecreaseChance()
    {
        currentChance = currentChance - 1;
        if (currentChance < 0) currentChance = 0;
    }

}