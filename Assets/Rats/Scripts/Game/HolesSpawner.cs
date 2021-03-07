using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HolesSpawner : MonoBehaviour
{

    [SerializeField]
    private WorldController worldController;

    [SerializeField]
    private Hole holePrefab;

    [SerializeField]
    private FloatParameter minSpawnTime;

    [SerializeField]
    private FloatParameter maxSpawnTime;

    [SerializeField]
    private FloatParameter holeDecreasingMultiplier;

    private float nextSpawnTime;

    private float time;

    private void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime.GetValue(), maxSpawnTime.GetValue());
    }

    private void Update()
    {
        time = Time.time;
        if(Time.time >= nextSpawnTime)
        {
            SpawnHole();
        }
    }

    private void SpawnHole()
    {
        worldController.TrySpawnHole();
      
        float m = GameManager.instance.GetCurrentDifficulty() * holeDecreasingMultiplier.GetValue();
        
        float min = minSpawnTime.GetValue();
        float max = maxSpawnTime.GetValue();
        if(min - m < minSpawnTime.GetMinValue())
        {
            min = minSpawnTime.GetMinValue();
        }
        else
        {
            min = min - m;
        }
        if (max - m < maxSpawnTime.GetMinValue())
        {
            max = maxSpawnTime.GetMinValue();
        }
        else
        {
            max = max - m;
        }
        

        nextSpawnTime = Time.time + Random.Range(min, max);
    }

}