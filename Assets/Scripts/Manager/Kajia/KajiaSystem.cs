using System.Collections.Generic;
using UnityEngine;
using PoketAPI.Camera;
using System.Linq;
public class KajiaSystem : MonoBehaviour, I_Manager
{
    public GameManager gameManager;
    [SerializeField] private SCR_KajiaSettings activeSettings;
    [SerializeField] private List<SCR_Events> enemyEvents = new();
    [SerializeField] private List<SCR_Events> itemEvents = new();
    [SerializeField] private List<SCR_Events> eventEvents = new();
    [HideInInspector] public SCR_Events[] choosenItems;
    [HideInInspector] public SCR_Events[] addedEnemies;
    private List<SCR_Events> allActiveItems = new();
    private List<SCR_Events> allActiveEnemies = new();
    [HideInInspector] public bool allowSpawnStart = false;
    private float nextSpawnTime = 0;
    private float timeSinceLastSpawn = 0;
    private C_KajiaSettings activeCSettings;
    private Vector2[] spawnPoints;
    [HideInInspector] public List<GameObject> objectPool = new();

    public void GameStart()
    {
        allActiveItems.AddRange(choosenItems);
        allActiveItems.AddRange(itemEvents);

        allActiveEnemies.AddRange(enemyEvents);
        allActiveEnemies.AddRange(addedEnemies);
    }

    void Update()
    {
        if (!allowSpawnStart)
            return;

        if (timeSinceLastSpawn < nextSpawnTime)
        {
            timeSinceLastSpawn += Time.deltaTime * GameTime.Instance.EventTime;
            return;
        }
        nextSpawnTime = 1;
        timeSinceLastSpawn = 0;
        SpawnObj();
    }

    private void SpawnObj()
    {
        C_KajiaSettings tempSetting = activeSettings.scoreStages[GetActiveCSetting()];
        //Refresh spawn points
        if (tempSetting != activeCSettings)
        {
            spawnPoints = CalcSpawnPoints(tempSetting.useWidthPersantege);
            activeCSettings = tempSetting;
        }

#if UNITY_EDITOR
        vector2s = spawnPoints;
#endif
        SCR_Events tempSCR = null;

        // Check and activate event
        if (eventEvents.Count != 0 && CheckEventChance(activeCSettings.eventChance))
        {
            tempSCR = Spawner.Instance.ChooseByPercentage(activeCSettings.possibleEvents.ToList(), Random.Range(0, 100));
            GameObject tempObj = Spawner.Instance.Spawn(tempSCR.eventObject, objectPool);

            StartEvent(tempSCR, tempObj);
            return;
        }
        //Check item spawn
        if (CheckItemRarity(activeCSettings.itemRarity))
        {
            tempSCR = Spawner.Instance.ChooseByPercentage(allActiveItems, Random.Range(0, 101));
        }
        else
        {
            tempSCR = Spawner.Instance.ChooseByPercentage(allActiveEnemies, Random.Range(0, 100)); 
        }

        SpawnSomething(tempSCR);
    }
    public void SpawnSomething(SCR_Events scr_event)
    {
        Spawner.Instance.Spawn(scr_event.eventObject, objectPool, GetSpawnPos()).GetComponent<I_KajiaControlls>().SetKajiaValues(this);
    }
    
    private Vector2 nextSpawnPoint = Vector2.zero;
    public Vector2 GetSpawnPos()
    {
        Vector2 tempPos = spawnPoints[0];

        if (nextSpawnPoint != Vector2.zero)
        {
            tempPos = nextSpawnPoint;
            nextSpawnPoint = Vector2.zero;
            return tempPos;
        }

        if (!activeCSettings.smartDrops)
        {
            tempPos = spawnPoints[Random.Range(0, spawnPoints.Length)];
            return tempPos;
        }




        return tempPos;
    }

    private bool CheckItemRarity(int itemRarity)
    {
        return itemRarity >= Random.Range(0, 100);
    }

    private void StartEvent(SCR_Events tempSCR, GameObject tempObj)
    {
        tempObj.GetComponent<I_KajiaControlls>().SetKajiaValues(this);

    }

    private bool CheckEventChance(int chance)
    {
        if (chance <= UnityEngine.Random.Range(0, 100))
        {
            return true;
        }
        return false;
    }

    private Vector2[] CalcSpawnPoints(float useWidthPersantege)
    {
        float width = CameraData.GetWidth();
        width -= width * 0.1f;

        float plusX = ((width * (useWidthPersantege / 100)));

        float lastXPos = -(width / 2);

        float yPos = CameraData.GetHight() / 2 + 0;

        List<Vector2> tempVec = new();

        for (int i = 0; ; i++)
        {
            tempVec.Add(new(lastXPos, yPos));

            if ((lastXPos + plusX) > (width / 2))
            {
                tempVec[i] = new(width / 2, yPos);
                break;
            }

            lastXPos += plusX;
        }

        return tempVec.ToArray();
    }

    private int GetActiveCSetting()
    {
        int score = gameManager.Score;
        int tempInt = 0;

        for (int i = 0; i < activeSettings.scoreStages.Length; i++)
        {
            if (i + 1 >= activeSettings.scoreStages.Length)
            {
                tempInt = i;
                break;
            }

            if (activeSettings.scoreStages[i].validAtScore <= tempInt)
            {
                tempInt = i;
            }
        }
        return tempInt;
    }

    public void PauseGame()
    {
    }
    public void GameEnd()
    {
        allowSpawnStart = false;

        allActiveItems.Clear();
        allActiveEnemies.Clear();

        for (int i = 0; i < objectPool.Count; i++)
        {
            if (objectPool[i] != null)
            {
                objectPool[i].GetComponent<I_KajiaControlls>().KillObj();
            }
        }
    }

    public void UnPauseGame(){}
  
#if UNITY_EDITOR
    private Vector2[] vector2s;
    void OnDrawGizmos()
    {
        if (vector2s == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < vector2s.Length; i++)
            Gizmos.DrawSphere(vector2s[i], 0.1f);
    }

#endif
}
