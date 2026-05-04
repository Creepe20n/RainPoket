using UnityEngine;

public class B_QuestModul : MonoBehaviour
{
    public virtual bool CheckQuestFinished()
    {
        return false;
    }

    public virtual void UpdateQuestValues()
    {
        
    }
    public virtual int GetQuestValues()
    {
        return 0;
    }
}
