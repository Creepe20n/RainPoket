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
    private void HandleItemEvent(E_StatisticEventType e_StatisticEventType,E_IETypes e_IETypes,E_StatisticData e_StatisticData)
    {
        if (!statData.ContainsKey(e_IETypes))
        {
            statData.Add(e_IETypes,new());
        }

        statData[e_IETypes].counts[(int)e_StatisticEventType][(int)e_StatisticData]++;
    }
    public void GameEnd()
    {
        throw new System.NotImplementedException();
    }

    public void GameStart()
    {
        throw new System.NotImplementedException();
    }

    public void PauseGame()
    {
        throw new System.NotImplementedException();
    }

    public void UnPauseGame()
    {
        throw new System.NotImplementedException();
    }
}
