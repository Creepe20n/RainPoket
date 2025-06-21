using System.Collections.Generic;
using UnityEngine;
using PoketAPI.Touch;
using System;

public class Dev_MenuManager : MonoBehaviour
{
    [SerializeField] GameObject devMenu;
    [Header("GUI Builder varibels")]
    [SerializeField] private Dev_GUIBuilder dev_GUIBuilder;
    [SerializeField] private RectTransform buildInTransform;
    [SerializeField] private GameObject spawnInParent;
    [Header("All Items/Enemies/Perks")]
    [SerializeField] private SCR_Events[] itemEvents; 
    [SerializeField] private SCR_Events[] enemyEvents;
    [SerializeField] private SCR_Events[] perkEvents;

    private bool blockStart;
    private E_DevSelection activeMenuType;
    private List<GameObject> objectPool = new();


    void Update()
    {
        if (!GetTab.DoubleTab(3))
            return;

        if (blockStart)
            return;

        OpenDevMenu();
        blockStart = true;
    }

    private void OpenDevMenu()
    {
        devMenu.SetActive(true);
        GameTime.Instance.GameDeltaTime = 0;

        SCR_Events[] temp = null;
        temp = (int)activeMenuType switch
        {
            0 => itemEvents,
            1 => enemyEvents,
            2 => perkEvents,
            _ => itemEvents,
        };
        
        dev_GUIBuilder.BuildGUIWithEvnt(
            temp,
            buildInTransform,
            spawnInParent,
            objectPool,
            4
        );
    }


}
