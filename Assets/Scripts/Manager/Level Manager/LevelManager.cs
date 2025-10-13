using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// For "displaying" and adding items/enemies at surtend level
/// </summary>
public class LevelManager : MonoBehaviour, I_Manager
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private C_Level[] levelData;

    //Level system varibles
    private int _level = 0;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
        }
    }
    private int _levelPoints = 0;
    /// <summary>
    /// Add level points, 100 = +1 level
    /// </summary>
    public int LevelPoints
    {
        get => _levelPoints;
        set
        {
            if (value >= 100)
            {
                Level += value / 100;
                _levelPoints = value % 100;
            }
            else
            {
                _levelPoints = value;
            }
        }
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
    /// <summary>
    /// Returns all items or Enemies till a pesicfic level
    /// </summary>
    /// <param name="tillLevel"></param>
    /// <returns>an array if true, empty array if false</returns>
    public SCR_Events[] GetAllTillLevel(int tillLevel, E_Level eventType)
    {
        if (eventType == E_Level.None)
            return null;

        List<SCR_Events> tempItems = new();

        for (int i = 0; i < levelData.Length; i++)
        {
            if (tillLevel < levelData[i].level)
                continue;

            switch (eventType)
            {
                case E_Level.Item:
                    tempItems.AddRange(levelData[i].addItemsToPool);
                    break;

                case E_Level.Enemy:
                    tempItems.AddRange(levelData[i].addEnemiesToPool);
                    break;
            }
        }

        return tempItems.ToArray();
    }
    /// <summary>
    /// Get all Items or Enemies at pasific level as array
    /// </summary>
    /// <param name="level"></param>
    /// <returns>arry if true and null if false</returns>
    public SCR_Events[] GetAllAtLevel(int level, E_Level eventType)
    {
        for (int i = 0; i < levelData.Length; i++)
        {
            if (levelData[i].level != level)
                continue;

            switch (eventType)
            {
                case E_Level.Item:
                    return levelData[i].addItemsToPool;

                case E_Level.Enemy:
                    return levelData[i].addEnemiesToPool;
            }
        }
        return null;
    }
}
