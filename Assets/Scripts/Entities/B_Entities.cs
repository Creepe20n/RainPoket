using UnityEngine;

public class B_Entities : MonoBehaviour, I_HitObj
{
    protected int _health = 10;
    public virtual void Hit(int damage = 0)
    {
        _health += damage;

        if (_health <= 0)
            Die();
    }
    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
