using UnityEngine;

public class B_Entities : MonoBehaviour,I_HitObj
{
    public int health = 10;

    public virtual void Hit(int damage = 0)
    {
        health -= damage;
    }
}
