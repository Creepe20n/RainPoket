using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Dev_GUIBuilder : MonoBehaviour
{
    [SerializeField] private GameObject baseIcon;
    public List<GameObject> BuildGUIWithEvnt(SCR_Events[] events, RectTransform buildInGUI, GameObject parent, List<GameObject> objectPool = null, int colums = 4)
    {
        float width = buildInGUI.rect.width * 0.7f;

        float plusWidth = width / colums;
        float minusHeight = plusWidth* 1.2f;


        float startX = -(width / 2);
        float startY = buildInGUI.rect.height * 0.3f;

        Vector2 activePos = new(startX, startY);


        for (int i = 0; i < events.Length; i++)
        {
            //Spawn or get Obj
            GameObject temp = Spawner.Instance.ObjectPool(baseIcon, objectPool);

            if (temp == null)
            {
                temp = Instantiate(baseIcon, parent.transform);
                objectPool.Add(temp);
            }
            temp.transform.SetParent(parent.transform);
            temp.transform.localPosition = activePos;
            temp.transform.localScale = new(plusWidth * 0.01f, plusWidth * 0.01f);
            temp.SetActive(true);

            //Set Obj Values
            if (events[i].icon == null)
            {
                temp.GetComponentInChildren<TextMeshProUGUI>().text = events[i].name;
            }
            else
            {
                temp.GetComponent<Image>().sprite = events[i].icon;
            }

            //Calculate next Obj Pos
            if (i % colums == 0 && i != 0)
            {
                activePos.x = startX;
                activePos.y -= minusHeight;
            }
            else
            {
                activePos.x += plusWidth;
            }
        }

        return objectPool;
    }
}
