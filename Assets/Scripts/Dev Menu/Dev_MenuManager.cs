using System.Collections.Generic;
using UnityEngine;
using PoketAPI.Touch;
using System;
using TMPro;
public class Dev_MenuManager : MonoBehaviour
{
    [SerializeField] private KajiaSystem kajiaSystem;
    [SerializeField] private SelectionMenu selectionMenu;
    [SerializeField] GameObject devMenu;
    [Header("GUI Builder varibels")]
    [SerializeField] private GameObject baseIcon;
    [SerializeField] private RectTransform buildInTransform;
    [SerializeField] private GameObject spawnInParent;
    [Header("All Items/Enemies/Perks")]
    [SerializeField] private SCR_Events[] itemEvents;
    [SerializeField] private SCR_Events[] enemyEvents;
    [SerializeField] private SCR_Events[] perkEvents;

    private List<GameObject> spawnPanels = new();
    private bool blockStart;
    private E_DevSelection activeMenuType = 0, oldMenuType = E_DevSelection.events;
    private List<GameObject> objectPool = new();

    void Update()
    {

        if (blockStart)
        {
            GameTime.Instance.GameDeltaTime = 0;
            return;
        }

        if (!GetTab.DoubleTab(3))
            return;

        OpenDevMenu();
        blockStart = true;
    }

    private void OpenDevMenu()
    {
        devMenu.SetActive(true);

        if (activeMenuType == oldMenuType)
            return;

        oldMenuType = activeMenuType;

        SCR_Events[] temp = null;
        temp = (int)activeMenuType switch
        {
            0 => itemEvents,
            1 => enemyEvents,
            2 => perkEvents,
            _ => itemEvents,
        };

        for (int i = 0; i < spawnPanels.Count; i++)
        {
            Destroy(spawnPanels[i]);
        }

        spawnPanels.Clear();

        for (int i = 0; i < temp.Length; i++)
        {
            GameObject tempObj = Instantiate(baseIcon, buildInTransform);

            tempObj.GetComponentInChildren<TextMeshProUGUI>().text = temp[i].name;
            tempObj.GetComponent<DevButton>().SetValues(temp[i], this);

            spawnPanels.Add(tempObj);
        }
    }

    public void CloseDevMenu()
    {
        blockStart = false;
        GameTime.Instance.GameDeltaTime = 1;
        devMenu.SetActive(false);
    }

    public void OpenItemMenu()
    {
        activeMenuType = E_DevSelection.items;
        OpenDevMenu();
    }

    public void OpenPerkMenu()
    {
        activeMenuType = E_DevSelection.perks;
        OpenDevMenu();
    }

    public void OpenEnemyMenu()
    {
        activeMenuType = E_DevSelection.enemys;
        OpenDevMenu();
    }

    public void TriggerEvent(SCR_Events scr_event)
    {
        switch ((int)activeMenuType)
        {
            case 0:
                kajiaSystem.SpawnSomething(scr_event);
                break;
            case 1:
                kajiaSystem.SpawnSomething(scr_event);
                break;
            case 2:
                selectionMenu.SpawnPerk(scr_event, 0);
                break;
        }

        CloseDevMenu();
    }
}
