using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionMenu : MonoBehaviour, I_Manager
{
    [SerializeField] private SelectionUIManager selectionUIManager;
    [SerializeField] private KajiaSystem kajiaSystem;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private int autoPerkCount = 3;
    [SerializeField] private SCR_Events[] items;
    [SerializeField] private SCR_Events[] perks;
    [SerializeField] private SCR_Events[] activeItems;
    [SerializeField] private SCR_Events[] activePerks;
    private List<GameObject> objectPool = new();

    public void SetPerk(int onPlace, int perkNum)
    {
        activePerks[onPlace] = perks[perkNum];
    }
    public void SetItem(int onPlace, int itemNum)
    {
        activeItems[onPlace] = items[itemNum];
    }

    public void ClearPerk(int onPlace)
    {
        activePerks[onPlace] = null;
    }
    public void ClearItem(int onPlace)
    {
        activeItems[onPlace] = null;
    }

    public void GameStart()
    {
        print(levelManager.Level);
        //Set Kajia Values 
        kajiaSystem.addedEnemies = levelManager.GetAllTillLevel(levelManager.Level, E_Level.Enemy);
        kajiaSystem.choosenItems = levelManager.GetAllTillLevel(levelManager.Level, E_Level.Item).Concat(activeItems).ToArray();

        //Activate Perks
        for (int i = 0; i < activePerks.Length; i++)
        {
            GameObject tempObj = Spawner.Instance.Spawn(activePerks[i].eventObject, objectPool);
            tempObj.GetComponent<I_KajiaControlls>().SetKajiaValues(kajiaSystem);
        }

        StartCoroutine(CreatePerks());
    }
    private IEnumerator CreatePerks()
    {
        for (int i = 0; i < autoPerkCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            int searchValue = Random.Range(0, 100);
            searchValue -= 100;

            if (searchValue < 0)
            {
                searchValue *= -1;
            }

            SCR_Events tempEvent = Spawner.Instance.ChooseByPercentage(perks.ToList(), searchValue);
            SpawnPerk(tempEvent,i);
        }


        //allow Kajia to start time
        yield return new WaitForSeconds(4);

        kajiaSystem.allowSpawnStart = true;
    }
    public void SpawnPerk(SCR_Events perk = null, int field = 0)
    {
        GameObject tempObj = Spawner.Instance.Spawn(perk.eventObject, objectPool);
        tempObj.GetComponent<I_KajiaControlls>().SetKajiaValues(kajiaSystem);
        
        selectionUIManager.SetPerkAnimation(field, perk.icon);
    }

    public void GameEnd()
    {
        selectionUIManager.ResetGameGUI();
        for (int i = 0; i < objectPool.Count; i++)
        {
            objectPool[i].GetComponent<I_KajiaControlls>().KillObj();
        }
    }

    public void PauseGame()
    {

    }

    public void UnPauseGame()
    {

    }
}
