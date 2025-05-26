using UnityEngine;

public class B_player : B_Entities
{
    private E_FreezeState _movementFreezeState = E_FreezeState.FreezeY;
    public E_FreezeState movemendFreezeState { set {
            if (value != E_FreezeState.None)
            {
                _movementFreezeState = value;
            }
        }
        get => _movementFreezeState;
    }
    public float playerMovementSpeed = 1;
}
