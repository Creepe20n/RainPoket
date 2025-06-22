using UnityEngine;

public class EY_RainDrop : EV_ChangePlayerData
{
    [SerializeField] private GameObject hail;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EY_Snowflake"))
        {
            Spawner.Instance.Spawn(hail, kajiaSystem.objectPool,transform.position).GetComponent<I_KajiaControlls>().SetKajiaValues(kajiaSystem);
            EndObjAction();
            return;
        }

        base.OnTriggerEnter2D(collision);
    }
}
