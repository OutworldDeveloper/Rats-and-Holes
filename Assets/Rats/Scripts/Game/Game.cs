using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public bool isPaused { get; private set; }

    [SerializeField]
    public Player player;

    [SerializeField]
    private UIPanel pausePanel;

    [SerializeField]
    private UIController controller;

    [SerializeField]
    private PauseScreenController pause;

    private void SetPause(bool b)
    {
        player.enabled = !b;
        if (b)
        {
            player.EnableDeadeye(false);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ShowPause(bool b)
    {
        if (b == isPaused) return;
        isPaused = b;
        SetPause(b);
        if (b == true)
        {
            controller.OpenPanel(pausePanel);
        }
        //ui_pause.SetActive(b);
    }

    public void Restart()
    {
        SceneLoader.instance.LoadScene(2);
    }

    public void Exit()
    {
        SceneLoader.instance.LoadScene(1);
    }

    private void Start()
    {
        GameManager.instance.OnGameEnded += Instance_OnGameEnded;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameEnded -= Instance_OnGameEnded;
    }

    private void Instance_OnGameEnded(GameResults gameResults)
    {
        GameOver();
    }

    private void Update()
    {
        if (player.health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowPause(true);
            }
        }
    }
    private void GameOver()
    {
        SetPause(false);

        player.EnableDeadeye(false);
        player.enabled = false;
        Time.timeScale = 0;
    }

}