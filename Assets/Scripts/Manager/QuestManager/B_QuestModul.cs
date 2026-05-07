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
    public virtual Vector3 GetQuestValues(StatisticManager statisticManager)
    {
        return Vector3.down;
    }
    public virtual void StartQuest(StatisticManager statisticManager)
    {
        
    }
}
