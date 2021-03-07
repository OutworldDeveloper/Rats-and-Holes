using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsManager : MonoBehaviour
{

    [SerializeField]
    private StatisticVariable stat_TimeSurvivedRecord;

    [SerializeField]
    private StatisticVariable stat_RatsKilledTotal;

    [SerializeField]
    private StatisticVariable stat_RatsKilledRecord;

    [SerializeField]
    private StatisticVariable stat_Deadeye;

    public void Rewards(GameResults gameResults)
    {
        if (PlayerProfile.playCustoms)
        {
            return;
        }
        else
        {
            PlayerProfile.AddMoney(gameResults.money);
            stat_TimeSurvivedRecord.SetStatistic((int)gameResults.score);
            stat_RatsKilledTotal.SetStatistic(gameResults.ratsKilled);
            stat_RatsKilledRecord.SetStatistic(gameResults.ratsKilled);
            if (gameResults.deadeyeUsed <= 0)
            {
                stat_Deadeye.SetStatistic((int)gameResults.score);
            }
        }
        AchievementManager.TryUnlock();
    }

}