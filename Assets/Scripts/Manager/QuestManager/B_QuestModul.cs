using UnityEngine;

public class B_QuestModul : MonoBehaviour
{
    public virtual bool CheckQuestFinished(StatisticManager statisticManager)
    {
        return false;
    }

    public virtual void UpdateQuestValues(StatisticManager statisticManager)
    {
        
    }
    /// <summary>
    /// (Percentage | curentValue | EndValue)
    /// </summary>
    /// <param name="statisticManager"></param>
    /// <returns></returns>
    public virtual Vector3 GetQuestValues(StatisticManager statisticManager)
    {
        return Vector3.down;
    }
    public virtual void StartQuest(StatisticManager statisticManager)
    {
        
    }
    public virtual bool CheckQuestValidForRun(C_ActiveRunData c_ActiveRunData)
    {
        return true;
    }
}
