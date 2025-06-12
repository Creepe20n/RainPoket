using System;
using UnityEngine;

public class B_player : B_Entities
{
    [SerializeField] private int startHealth = 3;
    [SerializeField] private E_FreezeState standartFreezeState = E_FreezeState.FreezeY;
    public Freezeble freezeble;
    private GameObject _graveStone;
    private GameObject activeGraveStone;
    public GameObject GraveStone
    {
        get => _graveStone;
        set
        {
            _graveStone = value;

            if (activeGraveStone != null)
            {
                Destroy(activeGraveStone);
                activeGraveStone = null;
            }
        }
    }

    void Start()
    {
        ResetPlayer();
    }
   
    public int PlayerHealth
    {
        get => health;
        private set { }
    }

    public override void Die()
    {
        if (activeGraveStone == null)
        {
            activeGraveStone = Instantiate(_graveStone, transform.position, Quaternion.identity);
        }
        activeGraveStone.transform.position = transform.position;
        activeGraveStone.SetActive(true);
    
        base.Die();
    }
    public void ResetPlayer()
    {
        if (activeGraveStone != null)
            activeGraveStone.SetActive(false);

        if (freezeble != null)
            freezeble.UnFreeze();
        
        health = startHealth;
        E_FreezeState = standartFreezeState;
        MovementSpeed = movementStartSpeed;
        gameObject.SetActive(true);
    }
}
