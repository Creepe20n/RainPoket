using System;
using UnityEngine;

public class B_player : B_Entities
{
    private E_FreezeState _movementFreezeState = E_FreezeState.FreezeY;
    [SerializeField] private int startHealth = 3;

    void Start()
    {
        ResetPlayer();
    }

    public E_FreezeState MovemendFreezeState
    {
        set
        {
            if (value != E_FreezeState.None)
            {
                _movementFreezeState = value;
            }
        }
        get => _movementFreezeState;
    }
    [SerializeField] private float playerMovementStartSpeed = 1;
    private float _playerMovementSpeed = 1;

    public float PlayerMovementSpeed
    {
        get => _playerMovementSpeed;
        set
        {
            _playerMovementSpeed = Mathf.Clamp(value, 0, 5);
        }
    }
    public int PlayerHealth
    {
        get => _health;
        private set { }
    }

    public void ResetPlayer()
    {
        _health = startHealth;
        _movementFreezeState = E_FreezeState.FreezeY;
        PlayerMovementSpeed = playerMovementStartSpeed;
        gameObject.SetActive(true);
    }
}
