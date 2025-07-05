using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class B_Item : B_ID, I_KajiaControlls
{
    protected KajiaSystem kajiaSystem;
    protected B_player b_Player;
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
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Normaly called by Kajia to set the values of the item.
    /// </summary>
    /// <param name="kajia"></param>
    public virtual void SetKajiaValues(KajiaSystem kajia)
    {
        if (kajiaSystem == null) kajiaSystem = kajia;
        if(b_Player == null) b_Player = kajia.gameManager.player.GetComponent<B_player>();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer(collision.gameObject);
            EndObjAction();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            HitGround();
            EndObjAction();
        }
    }
    /// <summary>
    /// This method is called when the item collides with the player.
    /// </summary>
    public virtual void HitPlayer(GameObject player = null)
    {
        FullfillAction();
    }
    /// <summary>
    /// This method is called when the item collides with the ground.
    /// </summary>
    public virtual void HitGround()
    {
        KillObj();
    }
}
