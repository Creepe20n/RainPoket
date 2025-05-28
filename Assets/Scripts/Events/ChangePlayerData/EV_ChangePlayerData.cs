using UnityEngine;

public class EV_ChangePlayerData : MonoBehaviour, I_KajiaControlls
{
    [Header("Hit Ground")]
    [SerializeField] private int changeHealthOnGround;
    [SerializeField] private float changePlayerSpeedOnGround;
    [SerializeField] private E_FreezeState changeFreezeStateOnGround;
    [Header("Hit Player")]
    [SerializeField] private int changeHealthOnPlayer;
    [SerializeField] private float changePlayerSpeedOnPlayer;
    [SerializeField] private E_FreezeState changeFreezeStateOnPlayer;

    private B_player player;

    public void KillObj()
    {
        gameObject.SetActive(false);
    }

    public void EndObjAction()
    {
        KillObj();
    }

    public void SetKajiaValues(KajiaSystem kajia)
    {
        player = kajia.gameManager.player.GetComponent<B_player>();
    }

    public void FullfillAction()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ChangePlayerDataPlayer();
            }
            if (collision.collider.CompareTag("Ground"))
            {
                ChangePlayerDataGround();
            }
        }
        catch { }
        EndObjAction();
    }

    private void ChangePlayerDataGround()
    {
        player.MovemendFreezeState = changeFreezeStateOnGround;
        player.PlayerMovementSpeed += changePlayerSpeedOnGround;
        player.health += changeHealthOnGround;
    }
    private void ChangePlayerDataPlayer()
    {
        player.MovemendFreezeState = changeFreezeStateOnPlayer;
        player.PlayerMovementSpeed += changePlayerSpeedOnPlayer;
        player.health += changeHealthOnPlayer;
    }
}
