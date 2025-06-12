using UnityEngine;

public class B_Entities : MonoBehaviour, I_HitObj
{
    protected int health = 10;

    [SerializeField] protected float maxMovementSpeed = 5;
    [SerializeField] protected float movementStartSpeed = 1;
    protected float _movementSpeed = 1;
    public float MovementSpeed
    {
        get => _movementSpeed;
        set
        {
            _movementSpeed = Mathf.Clamp(value, -maxMovementSpeed, maxMovementSpeed);
        }
    }

    protected E_FreezeState _freezeState = E_FreezeState.FreezeY;

    public E_FreezeState E_FreezeState
    {
        set
        {
            if (value != E_FreezeState.None)
                _freezeState = value;
        }
        get => _freezeState;
    }
    public virtual void Hit(int damage = 0)
    {
        health += damage;

        if (health <= 0)
            Die();
    }
    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
