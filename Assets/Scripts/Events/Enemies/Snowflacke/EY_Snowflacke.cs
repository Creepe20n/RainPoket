using UnityEngine;

public class EY_Snowflacke : B_Item
{
    [SerializeField] float freezeTime = 4f;
    public override void HitPlayer(GameObject player = null)
    {
        try
        {
            player.GetComponent<Freezeble>().Freeze(freezeTime);
        }
        catch { }
        KillObj();
    }
}
