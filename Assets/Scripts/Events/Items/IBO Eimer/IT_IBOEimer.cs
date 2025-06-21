using UnityEngine;

public class IT_IBOEimer : B_Item
{
    [SerializeField] private GameObject prefabIBOEimer;

    public override void HitPlayer(GameObject player = null)
    {
        try
        {
            EntitiyBody entitiyBody = player.GetComponent<EntitiyBody>();

            if (entitiyBody.HeadSlotState)
                return;

            entitiyBody.HeadSlot = Instantiate(
                prefabIBOEimer,
                new Vector2(
                    entitiyBody.HeadCenterPos.x,
                    entitiyBody.HeadCenterPos.y + player.GetComponent<SpriteRenderer>().bounds.extents.y
                ),
                Quaternion.identity
            );

            entitiyBody.HeadSlot.GetComponent<IT_spwnd_IBOEimer>().gameManager = kajiaSystem.gameManager;

        }
        catch
        {

        }
    }
}
