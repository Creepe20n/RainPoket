using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PoketAPI.Camera;
public class KajiaSystem : MonoBehaviour, I_Manager
{
    public GameManager gameManager;
    [SerializeField] private SCR_KajiaSettings activeSettings;
    private List<SCR_Events> enemyEvents = new();
    private List<SCR_Events> itemEvents = new();
    private List<SCR_Events> eventEvents = new();
    [HideInInspector] public SCR_Events[] choosenItems;
    private List<SCR_Events> allActiveItems = new();
    [HideInInspector] public bool allowSpawnStart = false;
    private float nextSpawnTime = 0;
    private float timeSinceLastSpawn = 0;
    private C_KajiaSettings activeCSettings;
    private Vector2[] spawnPoints;

    public void GameStart()
    {
        allActiveItems.AddRange(choosenItems);
        allActiveItems.AddRange(itemEvents);
    }

    void Update()
    {
        if (!allowSpawnStart)
            return;

        if (timeSinceLastSpawn < nextSpawnTime)
        {
            timeSinceLastSpawn += Time.deltaTime * GameTime.Instance.GameRunTime;
            return;
        }
        nextSpawnTime = 1;
        timeSinceLastSpawn = 0;
        SpawnObj();
    }

    private void SpawnObj()
    {
        C_KajiaSettings tempSetting = activeSettings.scoreStages[GetActiveCSetting()];

        if (tempSetting != activeCSettings)
        {
            spawnPoints = CalcSpawnPoints(tempSetting.useWidthPersantege);
            activeCSettings = tempSetting;
        }

#if UNITY_EDITOR
        vector2s = spawnPoints;
#endif

        if (eventEvents.Count != 0)
        {
            
        }


    }

    private Vector2[] CalcSpawnPoints(float useWidthPersantege)
    {
        float width = CameraData.GetWidth();
        width -= width * 0.1f;

        float plusX = ((width * (useWidthPersantege / 100)));

        float lastXPos = -(width / 2);

        float yPos = CameraData.GetHight() / 2 + 0;

        List<Vector2> tempVec = new();

        for (int i = 0;; i++)
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
        int score = gameManager.score;
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
    }

    public void UnPauseGame()
    {
    }
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
