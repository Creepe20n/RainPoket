using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNameTxT;
    [SerializeField] private TextMeshProUGUI questDiscriptionTxT;
    [SerializeField] private TextMeshProUGUI questProgressTxT;
    [SerializeField] private Slider questProgressBar; //0-1
    private SCR_Quest activeQuest;
    public void SetupQuestCard(SCR_Quest quest)
    {
        questNameTxT.text = quest.questName;
        questDiscriptionTxT.text = quest.questDiscription;
        questProgressBar.value = quest.GetQuestProgressValue();
        questProgressTxT.text = quest.GetQuestProgressByDone().ToString();
        activeQuest = quest;
    }
}
