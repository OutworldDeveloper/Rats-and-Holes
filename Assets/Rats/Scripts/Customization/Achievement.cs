using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{

    public string achievementName;
    [TextArea]
    public string achievementDescription;

    public Sprite image;

    [Header("Requirement")]
    public List<RequirementStat> requirementStats = new List<RequirementStat>();

    [Header("Rewards")]
    public List<Clothes> rewards = new List<Clothes>();

    public int money;

}

[System.Serializable]
public struct RequirementStat
{

    public StatisticVariable stat;
    public int requirement;

    [SerializeField]
    private RequirementType type;

    public bool isRequirementAchived()
    {
        switch (type)
        {
            case RequirementType.less:
                return (stat.GetStatistic() < requirement);
            case RequirementType.lessOrEqually:
                return (stat.GetStatistic() <= requirement);
            case RequirementType.equally:
                return (stat.GetStatistic() == requirement);
            case RequirementType.more:
                return (stat.GetStatistic() > requirement);
            case RequirementType.moreOrEqually:
                return (stat.GetStatistic() >= requirement);
            default:
                return false;
        }
    }

    private enum RequirementType
    {
        less,
        lessOrEqually,
        equally,
        more,
        moreOrEqually
    }

}