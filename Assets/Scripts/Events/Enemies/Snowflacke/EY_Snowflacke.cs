using UnityEngine;

public class EY_Snowflacke : B_Item
{
    [SerializeField] private float freezeTime = 4f;
    public override void HitPlayer(GameObject player = null)
    {
        try
        {
            player.GetComponent<Freezeble>().Freeze(freezeTime);
        }
        catch { }
        KillObj();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
