using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour, I_Manager
{
    [SerializeField] private StatisticManager statisticManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SCR_Quest[] allQuests;
    [SerializeField] private int maxDailys = 3;
    [SerializeField] private GameObject preQuestCard;
    [SerializeField] private GameObject cardHolder;
    [SerializeField] private QuestCard[] questCards;
    private SCR_Quest[] generellQuests;
    private SCR_Quest[] dailyQuests;
    private List<SCR_Quest> allActiveQuests = new();
    private List<SCR_Quest> questsListining = new();
    void Start()
    {
        dailyQuests = new SCR_Quest[questCards.Length];
        CheckNewDailyQuest();
    }
    public void GameEnd()
    {
        
    }

    public void GameStart()
    {
        questsListining.Clear();
        for(int i = 0; i < allActiveQuests.Count; i++)
        {
            if (allActiveQuests[i].CheckQuestValidationForRun(gameManager.activeRunData))
            {
                questsListining.Add(allActiveQuests[i]);
            }
        }
    }

    public void PauseGame()
    {
        throw new System.NotImplementedException();
    }

    public void UnPauseGame()
    {
        throw new System.NotImplementedException();
    }
    private void CheckNewDailyQuest()
    {
        SetNewDailyQuests();
    }
    private void SetNewDailyQuests()
    {
        List<SCR_Quest> tempAllQuests = allQuests.ToList();

        for (int i = 0; i < dailyQuests.Length; i++)
        {
            int chosen = Random.Range(0, tempAllQuests.Count);
            dailyQuests[i] = tempAllQuests[chosen];
            tempAllQuests.RemoveAt(chosen);
            print(tempAllQuests.Count);

            questCards[i].SetupQuestCard(dailyQuests[i]);
        }
    }
}
