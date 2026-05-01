using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class B_Item : B_ID, I_KajiaControlls
{
    protected KajiaSystem kajiaSystem;
    protected B_player b_Player;
    public static event Action<E_StatisticEventType, E_IETypes, E_StatisticData> StatisticEvent;
    private C_StatisticEData eventDataContainer;

    void OnEnable()
    {
        CallOnSpawn();
    }
    /// <summary>
    /// This method is called when the action is finished.
    /// </summary>
    public virtual void EndObjAction()
    {
        KillObj();
    }
    /// <summary>
    /// This method fullfills the action of the item. 
    /// Normally called when the item collides with the player.
    /// </summary>
    public virtual void FullfillAction()
    {

    }
    /// <summary>
    /// This method is called to deactivate the item object.
    /// Called by Kajia when game ends;
    /// </summary>
    public virtual void KillObj()
    {
        CallEventOnDeath();
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Normaly called by Kajia to set the values of the item.
    /// </summary>
    /// <param name="kajia"></param>
    public virtual void SetKajiaValues(KajiaSystem kajia)
    {
        if (kajiaSystem == null) kajiaSystem = kajia;
        if (b_Player == null) b_Player = kajia.gameManager.player.GetComponent<B_player>();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            HitGround();
        }
        EndObjAction();
    }
    /// <summary>
    /// This method is called when the item collides with the player.
    /// </summary>
    public virtual void HitPlayer(GameObject player = null)
    {
        CallEventOnHit();
        FullfillAction();
    }
    /// <summary>
    /// This method is called when the item collides with the ground.
    /// </summary>
    public virtual void HitGround()
    {
    }
    /// <summary>
    /// Called when Obj dies without hitting an entitiy
    /// Sets None for IE Type on Deffault
    /// </summary>
    public virtual void CallEventOnDeath()
    {
        StatisticEvent?.Invoke(E_StatisticEventType.Died, objType, E_StatisticData.Death);

    }
    /// <summary>
    /// Call when Obj hits an Entity
    /// Sets None for IE Type on Deffault
    /// </summary>
    public virtual void CallEventOnHit()
    {
        StatisticEvent?.Invoke(E_StatisticEventType.Hitted, objType, E_StatisticData.Hit);

    }
    /// <summary>
    /// Call when obj gets set Active thrug spawn
    /// Sets None for IE Type on Deffault
    /// </summary>
    public virtual void CallOnSpawn()
    {
        StatisticEvent?.Invoke(E_StatisticEventType.Spawned, objType, E_StatisticData.Spawn);
    }
}
