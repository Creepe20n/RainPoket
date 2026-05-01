
using System;
using System.Collections.Generic;

public class C_StatisticEData
{
    public int deathCount = 0;
    public int spawnCount = 0;
    public int hitCount = 0;

    public List<List<int>> counts = new();

    public C_StatisticEData()
    {
        for (int i = 0; i < Enum.GetValues(typeof(E_StatisticEventType)).Length; i++)
        {
            counts.Add(new());

            for (int j = 0; j < Enum.GetValues(typeof(E_StatisticData)).Length; j++)
            {
                counts[i].Add(0);
            }
        }
    }
}
