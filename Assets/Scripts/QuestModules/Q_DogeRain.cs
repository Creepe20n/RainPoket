using UnityEngine;

public class Q_DogeRain : B_QuestModul
{
    protected int rainToDoge = 100;
    protected int rainAtQuestStart = 0;
    private int rainDoged = 0;
    [SerializeField] private string rainDropID;
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
        UpdateQuestValues(statisticManager);

        float perc = rainToDoge / rainDoged;

        return new Vector3(
            perc,
            rainDoged,
            rainToDoge
        );
    }
    public override void UpdateQuestValues(StatisticManager statisticManager)
    {
        int tempRain = statisticManager.GetStatisticData(E_StatisticEventType.Died, E_IETypes.Raindrop, E_StatisticData.Death);
        rainDoged = tempRain - rainAtQuestStart;
    }
    public override bool CheckQuestValidForRun(C_ActiveRunData c_ActiveRunData)
    {
        for(int i = 0; i < c_ActiveRunData.runEnemies.Length; i++)
        {
            try{
                if(c_ActiveRunData.runEnemies[i].eventObject.GetComponent<B_ID>().ObjID == rainDropID)
                {
                    return true;
                }
            }catch{}
        }
        return false;
    }

}
