using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class GameEndedEvent : UnityEvent<GameResults> { };


[RequireComponent(typeof(StatsManager))]
public class GameManager : MonoBehaviour
{

    public delegate void GameEnded(GameResults gameResults);

    public event GameEnded OnGameEnded;

    public static GameManager instance { get; private set; }

    public GameEndedEvent OnGameEndedEvent;

    [SerializeField]
    private RatsSpawner ratsSpawner;

    [SerializeField]
    private Player player;

    [SerializeField]
    private FloatParameter deadeyeGaining;

    [SerializeField]
    private FloatParameter timeMultiplier;

    private float timer;

    private StatsManager statsManager;

    private bool isGameEnded;

    public Player GetPlayer()
    {
        return player;
    }

    public float GetCurrentDifficulty()
    {
        //float f = Time.time - startTime + 1;
        //return Mathf.Log(f, 3) + f / currentDifficultySettings.difficultyMultiplier;
        float f = timer + 1;
        return Mathf.Log(f);
    }

    public float GetCurrentTime()
    {
        return timer;
    }

    public void SpawnRat(Vector3 position)
    {
        ratsSpawner.SpawnRat(position);
    }

    private void Awake()
    {
        instance = this;
        statsManager = GetComponent<StatsManager>();
    }

    private void Start()
    {
        StartGame();
        Rat.OnRatDied += Rat_OnRatDied;
        player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void OnDestroy()
    {
        Rat.OnRatDied -= Rat_OnRatDied;
        player.OnHealthChanged -= Player_OnHealthChanged;
    }

    private void Update()
    {
        timer = timer + Time.deltaTime * timeMultiplier.GetValue();
    }

    private void Rat_OnRatDied(Rat rat)
    {
        player.AddDeadeye(deadeyeGaining.GetValue());
    }

    private void StartGame()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(int health)
    {
        if(player.health <= 0 && isGameEnded == false)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isGameEnded = true;
        GameResults gameResults = new GameResults(GetCurrentTime(), statsManager.ratsKilled, statsManager.deadeyeTimer);
        if (OnGameEnded != null) OnGameEnded(gameResults);
        OnGameEndedEvent.Invoke(gameResults);
    }

}

public struct GameResults
{

    public GameResults(float score, int ratsKilled, float deadeyeUsed)
    {
        this.score = score;
        this.ratsKilled = ratsKilled;
        this.deadeyeUsed = deadeyeUsed;
        money = Mathf.FloorToInt(GameManager.instance.GetCurrentTime() / 50);
    }

    public float score;
    public int ratsKilled;
    public float deadeyeUsed;

    public int money;

}