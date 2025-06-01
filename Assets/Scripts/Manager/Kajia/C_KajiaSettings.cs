using System;
using UnityEngine;
[Serializable]
public class C_KajiaSettings
{
    public int validAtScore = 0;
    public bool smartDrops;
    [Range(1, 100)]
    public float useWidthPersantege = 50;//How much of the screen width is used for drops
    public SCR_Events[] possibleEvents;
    public int eventChance = 0;
    [Range(1,100)]
    public int itemRarity = 100; //Chance for an item, higher == more
}
