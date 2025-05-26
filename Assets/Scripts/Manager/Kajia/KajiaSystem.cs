using System.Collections.Generic;
using UnityEngine;

public class KajiaSystem : MonoBehaviour,I_Manager
{
    public GameManager gameManager;
    List<SCR_Events> enemyEvents = new();
    List<SCR_Events> itemEvents = new();
    List<SCR_Events> eventEvents = new();
    public void GameStart()
    {
        Debug.Log("Kajia Started");
    }
    public void PauseGame()
    {
        GameTime.Instance.EventTime = 0;
    }
    public void GameEnd()
    {
        Debug.Log("Kajia Ended");
    }

    public void UnPauseGame()
    {
    }
}
