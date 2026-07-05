using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Quest",menuName ="Game/Quest")]
public class SCR_Quest : ScriptableObject
{
    public string questName;
    [TextArea,SerializeField] public string questDiscription;
    [SerializeField] private List<SCR_Events> items = new();
    public List<SCR_Events> Items {get => items; private set{}}

    [SerializeField] private B_QuestModul[] b_QuestModuls;

    private bool questListining = false;

    public bool CheckQuestFinished(StatisticManager statisticManager)
    {
        for(int i = 0; i < b_QuestModuls.Length; i++)
        {
            if(!b_QuestModuls[i].CheckQuestFinished(statisticManager))
                return false;
        }

        return true;
    }
   
    /// <summary>
    /// Returns float between 0-1
    /// </summary>
    /// <returns></returns>
    public float GetQuestProgressPercentage(StatisticManager statisticManager)
    {
        float tempPerc = 0;

        for(int i = 0; i < b_QuestModuls.Length; i++)
        {
            tempPerc += b_QuestModuls[i].GetQuestValues(statisticManager).x;
        }
        return tempPerc;
    }
    public Vector2 GetQuestProgressByValue()
    {
        return new Vector2(0,10);
    }
    public bool CheckQuestValidationForRun(C_ActiveRunData c_ActiveRunData)
    {
        for(int i = 0; i < b_QuestModuls.Length; i++)
        {
            if(!b_QuestModuls[i].CheckQuestValidForRun(c_ActiveRunData))
                return false;
        }

        questListining = true;
        return true;
    }
    public void EndQuestListining()
    {
        
    }
}
