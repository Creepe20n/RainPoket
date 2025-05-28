using UnityEngine;

public class B_player : B_Entities
{
    private E_FreezeState _movementFreezeState = E_FreezeState.FreezeY;
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
    private float _playerMovementSpeed = 1;
    
    public float PlayerMovementSpeed
    {
        get => _playerMovementSpeed;
        set
        {
            _playerMovementSpeed = Mathf.Clamp(value, 0, 5);
        }
    }
}
