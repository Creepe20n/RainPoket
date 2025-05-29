using UnityEngine;
using PoketAPI.Camera;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.UI;
public class SelectionUIManager : MonoBehaviour
{
    [SerializeField] private SelectionMenu selectionMenu;
    private List<GameObject> destroyOnGameEndObj = new();
    [SerializeField] private GameObject perkAni;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private RectTransform canvasRect;
    private Vector2 lastPerkPos;
    public void SetPerkAnimation(int field, Sprite icon)
    {
        float width = canvasRect.rect.width;
        width -= width * 0.4f;

        float hight = canvasRect.rect.height;

        float startX = -width / 2;
        float plusX = width / 2;//Why 2? TF I know now haha 

        float startY = hight * 0.2f;
        float plusY = width * 0.4f;

        if (field == 0)
        {
            lastPerkPos.x = startX - plusX;
            lastPerkPos.y = startY;
        }

        if (lastPerkPos.x + plusX > 0 + width / 2)
        {
            lastPerkPos.x = startX;
            lastPerkPos.y -= plusY;
        }
        else
        {
            lastPerkPos.x += plusX;
        }

        GameObject tempObj = Instantiate(perkAni, gameCanvas.transform);
        tempObj.GetComponent<Image>().sprite = icon;
        tempObj.transform.localPosition = lastPerkPos;
        destroyOnGameEndObj.Add(tempObj);
    }
    public void ResetGameGUI()
    {
        for (int i = 0; i < destroyOnGameEndObj.Count; i++)
        {
            Destroy(destroyOnGameEndObj[i]);
        }
    }
}
