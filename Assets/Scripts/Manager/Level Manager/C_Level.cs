using UnityEngine;

public class C_Level
{
    [Range(1, 100)]
    public int level = 0;

    [Header("Items at Level")]
    public SCR_Events[] addItemsToPool;
    [Header("Enemies at Level")]
    public SCR_Events[] addEnemiesToPool;
    [Header("Events at Level")]
    public SCR_Events addEventsToPool;
}
