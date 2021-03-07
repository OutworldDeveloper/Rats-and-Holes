using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementManager 
{

    public delegate void AchievementUnlocked(Achievement achievement);

    public static event AchievementUnlocked OnAchievementUnlocked;

    private const string acheivementsPath = "achivement_";

    public static List<Achievement> GetLockedAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        foreach (var item in GetAchievements())
        {
            if (!isAchievementUnlocked(item))
            {
                achivements.Add(item);
            }
        }
        return achivements;
    }

    public static List<Achievement> GetAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        if (Resources.LoadAll<Achievement>("Achievement/").Length > 0)
        {
            foreach (var item in Resources.LoadAll<Achievement>("Achievement/"))
            {
                achivements.Add(item);
            }
        }
        return achivements;
    }

    public static void TryUnlock()
    {
        foreach (var achievement in GetLockedAchievements())
        {
            bool b = false;
            foreach (var requirementStat in achievement.requirementStats)
            {
                if (requirementStat.isRequirementAchived())
                {
                    b = true;
                }
                else
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                UnlockAcheivement(achievement);
            }
        }
    }

    private static void UnlockAcheivement(Achievement achievement)
    {
        if (!isAchievementUnlocked(achievement))
        {
            PlayerPrefs.SetInt(acheivementsPath + achievement.name, 1);
            if (OnAchievementUnlocked != null) OnAchievementUnlocked(achievement);
            foreach (var item in achievement.rewards)
            {
                item.Unlock();
            }
            PlayerProfile.AddMoney(achievement.money);
        }
    }

    public static bool isAchievementUnlocked(Achievement achievement)
    {
        return PlayerPrefs.GetInt(acheivementsPath + achievement.name) == 1;
    }

}