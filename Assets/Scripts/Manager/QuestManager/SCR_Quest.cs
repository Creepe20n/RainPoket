using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Quest",menuName ="Game/Quest")]
public class SCR_Quest : ScriptableObject
{
    [SerializeField] private string questName;
    [TextArea,SerializeField] private string questDiscription;
    [SerializeField] private List<SCR_Events> items = new();
    public List<SCR_Events> Items {get => items; private set{}}

    [SerializeField] private B_QuestModul[] b_QuestModuls;

    public bool CheckQuestFinished()
    {
        for(int i = 0; i < b_QuestModuls.Length; i++)
        {
            if(!b_QuestModuls[i].CheckQuestFinished())
                return false;
        }

        return true;
    }
}
