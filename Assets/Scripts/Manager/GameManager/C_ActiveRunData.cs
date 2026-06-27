using System.Collections.Generic;
using UnityEngine;

public class C_ActiveRunData
{
    public SCR_Events[] runPerks;
    public SCR_Events[] runItems;
    public SCR_Events[] runEnemies;
    
    public C_ActiveRunData(SCR_Events[] _runPerks, SCR_Events[] _runItems, SCR_Events[] _runEnemies)
    {
        runEnemies = _runEnemies;
        runItems = _runItems;
        runPerks = _runPerks;
    }
}
