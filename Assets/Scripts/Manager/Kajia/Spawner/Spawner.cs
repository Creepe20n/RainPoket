using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public GameObject Spawn(GameObject spawnObj, List<GameObject> objectPool, Vector2 pos = new Vector2())
    {
        GameObject tempObj = ObjectPool(spawnObj, objectPool);

        if (tempObj == null)
        {
            tempObj = Instantiate(spawnObj, pos, Quaternion.identity);
            objectPool.Add(tempObj);
        }
        tempObj.transform.position = pos;
        tempObj.SetActive(true);
        return tempObj;
    }

    public SCR_Events ChooseByPercentage(List<SCR_Events> list, int serchValue)
    {
        SCR_Events tempEvent = list[0];
        List<SCR_Events> possibleList = new();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].chance <= serchValue)
                possibleList.Add(list[i]);
        }

        if (possibleList.Count > 0)
        {
            tempEvent = possibleList[Random.Range(0, possibleList.Count)];
        }

        return tempEvent;
    }

    public GameObject ObjectPool(GameObject spawnObj, List<GameObject> objectPool)
    {
        GameObject tempObj = null;
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (objectPool[i].CompareTag(spawnObj.tag) && !objectPool[i].activeSelf)
            {
                tempObj = objectPool[i];
                break;
            }
        }

        return tempObj;
    }
}
