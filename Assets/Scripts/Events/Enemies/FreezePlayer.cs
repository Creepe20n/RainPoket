using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    [SerializeField] private float freezeTime;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Freezeble freezeble;
        try
        {
            freezeble = collision.gameObject.GetComponent<Freezeble>();
        }
        catch
        {
            return;
        }
        if (freezeble == null)
            return;
        
        if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHit(freezeble);
            }
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundHit(freezeble);
        }
    }

    public virtual void PlayerHit(Freezeble freezeble)
    {
        freezeble.Freeze(freezeTime);
    }

    public virtual void GroundHit(Freezeble freezeble)
    {
        freezeble.Freeze(freezeTime);
    }

}
