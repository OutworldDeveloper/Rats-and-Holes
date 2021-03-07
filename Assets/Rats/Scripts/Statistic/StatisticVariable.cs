using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Statistic Variable", menuName = "Statistic Variable")]
public class StatisticVariable : ScriptableObject
{

    private const string statisticPath = "rats_stat_";

    public string displayName;

    public StatisticType statisticType;

    public void SetStatistic(int newStat)
    {
        switch (statisticType)
        {
            case StatisticType.statistic:

                PlayerPrefs.SetInt(statisticPath + name, GetStatistic() + newStat);
                break;

            case StatisticType.record:

                if (GetStatistic() < newStat)
                {
                    PlayerPrefs.SetInt(statisticPath + name, newStat);
                }
                break;

            case StatisticType.antirecord:

                if (GetStatistic() > newStat)
                {
                    PlayerPrefs.SetInt(statisticPath + name, newStat);
                }
                break;

            case StatisticType.none:

                PlayerPrefs.SetInt(statisticPath + name, newStat);
                break;

            default:
                break;
        }
    }

    public int GetStatistic()
    {
        return PlayerPrefs.GetInt(statisticPath + name);
    }
    
}

public enum StatisticType
{
    statistic,
    record,
    antirecord,
    none
}