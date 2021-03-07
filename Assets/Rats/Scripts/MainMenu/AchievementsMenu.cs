using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementsMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject achivementsParent;

    [SerializeField]
    private AchievementUI achievementUIPrefab;

    [SerializeField]
    private TextMeshProUGUI textAchievementName, textAchievementDescription, textProgress, textMoneyReward;

    [SerializeField]
    private Image progressBar;

    public void SelectAchievement(Achievement achievement)
    {
        textAchievementName.text = achievement.achievementName;
        textAchievementDescription.text = achievement.achievementDescription;
        textMoneyReward.text = achievement.money + " points";
        float a = achievement.requirementStats[0].stat.GetStatistic();
        float b = achievement.requirementStats[0].requirement;
        textProgress.text = "Progress: " + a + " / " + b;
        progressBar.fillAmount = a / b;
    }

    private void Awake()
    {
        foreach (var item in AchievementManager.GetAchievements())
        {
            Instantiate(achievementUIPrefab, achivementsParent.transform, false).Setup(item, this);
        }
    }

    private void Start()
    {
        SelectAchievement(AchievementManager.GetAchievements()[0]);
    }

}