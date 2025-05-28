using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KajiaSystem : MonoBehaviour,I_Manager
{
    public GameManager gameManager;
    private List<SCR_Events> enemyEvents = new();
    private List<SCR_Events> itemEvents = new();
    private List<SCR_Events> eventEvents = new();
    [HideInInspector] public SCR_Events[] choosenItems;
    private List<SCR_Events> allActiveItems = new();
    [HideInInspector] public bool allowSpawnStart = false;
    public void GameStart()
    {
        allActiveItems.AddRange(choosenItems);
        allActiveItems.AddRange(itemEvents);
    }

    void Update()
    {
        if (!allowSpawnStart)
            return;

        
    }
    public void PauseGame()
    {
    }
    public void GameEnd()
    {
        allActiveItems.Clear();
        allowSpawnStart = false;
    }

    public void UnPauseGame()
    {
    }
}
