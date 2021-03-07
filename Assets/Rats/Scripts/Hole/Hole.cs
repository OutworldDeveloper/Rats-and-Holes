using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public event EventHandler OnStageUpdated;

    public event EventHandler OnRatSpawned;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private HoleStage[] holeStages;

    private int currentStage;

    private float nextStageTime;

    private void Start()
    {
        SetCurrentStage(0);
    }

    private void Update()
    {
        if (Time.time >= nextStageTime)
        {
            SetCurrentStage(currentStage + 1);
        }
    }

    private void SetCurrentStage(int i)
    {
        if(i <= holeStages.Length - 1)
        {
            currentStage = i;
            //sprite.sprite = holeStages[i].sprite;
            sprite.sprite = PlayerProfile.GetSelectedMap().holesSprites[i];
            nextStageTime = Time.time + UnityEngine.Random.Range(holeStages[i].stageTime, holeStages[i].stageTimeMax);

            if (holeStages[i].spawnEnemy)
            {
                if (OnRatSpawned != null) OnRatSpawned(this, EventArgs.Empty);
                GameManager.instance.SpawnRat(transform.position);
            }
            if (OnStageUpdated != null) OnStageUpdated(this, EventArgs.Empty);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}