using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VioletPortal : MonoBehaviour
{

    [SerializeField]
    private int enemiesCount = 3;

    [SerializeField]
    private Rat enemyPrefab;

    private float nextEnemyTime;
    private int enemySpawned;

    private void Update()
    {
        if(Time.time >= nextEnemyTime)
        {
            SpawnEnemy();
            if (enemySpawned >= enemiesCount)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void SpawnEnemy()
    {
        enemySpawned++;
        nextEnemyTime = Time.time + Random.Range(2, 4f);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

}