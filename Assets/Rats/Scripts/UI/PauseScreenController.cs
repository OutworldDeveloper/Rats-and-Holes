using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenController : MonoBehaviour
{

    [SerializeField]
    private Game game;

    [SerializeField]
    private GameObject ui_pause;

    [SerializeField]
    private TextMeshProUGUI ui_countdown;

    [SerializeField]
    private UIController controller;

    [SerializeField]
    private UIPanel panel;

    [SerializeField]
    private UIPanel hud;

    public void btn_Continue()
    {
        ui_pause.SetActive(false);
        ui_countdown.gameObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    private void OnEnable()
    {
        //ui_pause.SetActive(true);
        //ui_countdown.gameObject.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        int t = 3;
        while (t > 0)
        {
            ui_countdown.SetText(t.ToString());
            yield return new WaitForSecondsRealtime(1);
            t--;
        }
        controller.OpenPanel(hud);
        game.ShowPause(false);
    }

}