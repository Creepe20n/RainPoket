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
    private void HandleItemEvent(E_IETypes iETypes, C_StatisticEData c_StatisticEData)
    {
        if (!statData.ContainsKey(iETypes))
        {
            statData.Add(iETypes,c_StatisticEData);
            return;
        }
        statData[iETypes] = c_StatisticEData;
        
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
