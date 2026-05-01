using System;
using System.Collections.Generic;
using UnityEngine;

public class StatisticManager : MonoBehaviour, I_Manager
{
    private readonly Dictionary<E_IETypes, C_StatisticEData> statData = new();
    void Start()
    {
        B_Item.StatisticEvent += HandleItemEvent;
    }
    private void HandleItemEvent(E_StatisticEventType e_StatisticEventType,
    E_IETypes e_IETypes,
    E_StatisticData e_StatisticData)
    {
        if (!statData.ContainsKey(e_IETypes))
        {
            statData.Add(e_IETypes, new());
        }

        statData[e_IETypes].counts[(int)e_StatisticEventType][(int)e_StatisticData]++;
    }
    public int GetStatisticData(E_StatisticEventType e_StatisticEventType,
    E_IETypes e_IETypes,
    E_StatisticData e_StatisticData)
    {
        if (!statData.ContainsKey(e_IETypes))
            return -1;
        return statData[e_IETypes].counts[(int)e_StatisticEventType][(int)e_StatisticData];
    }
    public void GameEnd()
    {
    }

    public void GameStart()
    {
    }

    public void PauseGame()
    {
    }

    public void UnPauseGame()
    {
    }
}
