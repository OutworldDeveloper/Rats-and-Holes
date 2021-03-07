using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{

    [SerializeField]
    private Text ui_textName;

    [SerializeField]
    private Text ui_textDesc;

    [SerializeField]
    private Text ui_textRequirement;

    [SerializeField]
    private GameObject check;

    [SerializeField]
    private Image background;

    [SerializeField]
    private Color color;

    private Achievement targetAchievement;
    private AchievementsMenu achievementsMenu;

    public void Setup(Achievement achivement, AchievementsMenu menu)
    {
        targetAchievement = achivement;
        achievementsMenu = menu;
        ui_textName.text = achivement.achievementName;
        ui_textDesc.text = achivement.achievementDescription;
        string requirement = "Requirement: ";
        foreach (var item in achivement.requirementStats)
        {
            requirement += item.stat.displayName + ": " + item.stat.GetStatistic() + " / " + item.requirement + " ";
        }
        ui_textRequirement.text = requirement;
        check.SetActive(AchievementManager.isAchievementUnlocked(achivement));
        /*
        if(AchievementManager.isAchievementUnlocked(achivement))
        {
            background.color = color;
        }
        */
    }

    public void btn_Select()
    {
        achievementsMenu.SelectAchievement(targetAchievement);
    }

}