using UnityEngine;

public class Q_DogeRain : B_QuestModul
{
    protected int rainToDoge = 100;
    protected int rainAtQuestStart = 0;
    public override bool CheckQuestFinished(StatisticManager statisticManager)
    {
        int tempRain = statisticManager.GetStatisticData(E_StatisticEventType.Died, E_IETypes.Raindrop, E_StatisticData.Death);

        if(tempRain-rainAtQuestStart >= rainToDoge)
            return true;

        return false;
        
    }
    public override void StartQuest(StatisticManager statisticManager)
    {
        rainAtQuestStart = statisticManager.GetStatisticData(E_StatisticEventType.Died, E_IETypes.Raindrop, E_StatisticData.Death);
    }

    public override Vector3 GetQuestValues(StatisticManager statisticManager)
    {
        int tempRain = statisticManager.GetStatisticData(E_StatisticEventType.Died, E_IETypes.Raindrop, E_StatisticData.Death);

        return new Vector3(
            
        );
    }
    public override void UpdateQuestValues(StatisticManager statisticManager)
    {
    }

}
