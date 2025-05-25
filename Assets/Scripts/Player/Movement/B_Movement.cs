using UnityEngine;
using PoketAPI.Touch;
using PoketAPI.Convert;
public class B_Movement : MonoBehaviour
{
    [SerializeField] private B_player b_Player;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask blockLayer;
    [SerializeField] private float rayLength;
    [SerializeField] private SpriteRenderer spriteRenderer;


    private Vector2 touchPositon = Vector2.zero;

    void Update()
    {
        if (b_Player.movemendFreezeState == E_FreezeState.FreezeXY || !GetTouch.IsTouching())
        {
            animator.Play("idle");
            return;
        }

        touchPositon = GetTouch.Position();
        Vector2 movementVec = Vector2.zero;

        if (SettingsManager.Instance.useMovementType == E_Movement.ToPoint)
        {
            movementVec = ToPointMovement();
        }
        else
            movementVec = ToDirectionMovement();

        if (WallControll(movementVec))
        {
            animator.Play("idle");
            return;        
        }

        if (movementVec.x != 0)
        {
            spriteRenderer.flipX = movementVec.x < 0;
            animator.Play("move");
        }
        else
        {
            animator.Play("idle");
        }

        transform.Translate(b_Player.playerMovementSpeed * Time.deltaTime * movementVec);
    }
    //Move to touch point
    private Vector2 ToPointMovement()
    {
        Vector2 tempVec = Vector2.zero;
        //x 
        if (b_Player.movemendFreezeState != E_FreezeState.FreezeX)
        {
            tempVec.x = ConvertPosition.X_Distance(transform.position.x, touchPositon.x) > 0.1f ? 1 : 0;
            tempVec.x = touchPositon.x < transform.position.x ? tempVec.x * -1 : tempVec.x;
        }
        //y
        if (b_Player.movemendFreezeState != E_FreezeState.FreezeY)
        {
            tempVec.y = ConvertPosition.Y_Distance(transform.position.y, touchPositon.y) > 0.1f ? 1 : 0;
            tempVec.y = touchPositon.y < transform.position.y ? tempVec.y * -1 : tempVec.y;
        }

        return tempVec;
    }
    //Move in Touch direction
    private Vector2 ToDirectionMovement()
    {
        Vector2 tempVec = Vector2.zero;

        //x
        if (b_Player.movemendFreezeState != E_FreezeState.FreezeX)
        {
            tempVec.x = touchPositon.x > 0 ? 1 : -1;
            tempVec.x = touchPositon.x == 0 ? 0 : tempVec.x;
        }
        //y
        if (b_Player.movemendFreezeState != E_FreezeState.FreezeY)
        {
            tempVec.y = touchPositon.y > 0 ? 1 : -1;
            tempVec.y = touchPositon.y == 0 ? 0 : tempVec.y;
        }
        return tempVec;
    }

    private bool WallControll(Vector2 movementVec)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, movementVec, rayLength, blockLayer);
        return raycastHit2D;
    }

}
