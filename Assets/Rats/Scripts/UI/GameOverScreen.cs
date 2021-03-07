
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField]
    private StatisticVariable score;

    [SerializeField]
    private string newHightScoreText = "you achieved a new high score";

    [SerializeField]
    private string scoreText = "your score";

    [SerializeField]
    private string ratsKilledText = "rats killed";

    [SerializeField]
    private TextMeshProUGUI ui_time;

    [SerializeField]
    private TextMeshProUGUI ui_ratsKilled;

    [SerializeField]
    private TextMeshProUGUI ui_coins;

    [SerializeField]
    private Transform ui_achievementsParent;

    [SerializeField]
    private AchievementUI achievementuiPrefab;

    private void Start()
    {
        AchievementManager.OnAchievementUnlocked += AchievementManager_OnAchievementUnlocked;
    }

    private void OnDestroy()
    {
        AchievementManager.OnAchievementUnlocked -= AchievementManager_OnAchievementUnlocked;
    }

    private void AchievementManager_OnAchievementUnlocked(Achievement achievement)
    {
        Instantiate(achievementuiPrefab, ui_achievementsParent, false).Setup(achievement, null);
    }

    public void ShowStats(GameResults gameResults)
    {
        /*
        if (score.GetStatistic() < gameResults.score)
        {
            ui_time.text = gameResults.score.ToString();
        }
        else
        {
            ui_time.text = ((int)gameResults.score).ToString();
        }
        */
        ui_time.text = ((int)gameResults.score).ToString();
        ui_coins.text = gameResults.money.ToString();
        ui_ratsKilled.text = gameResults.ratsKilled.ToString();
    }

}