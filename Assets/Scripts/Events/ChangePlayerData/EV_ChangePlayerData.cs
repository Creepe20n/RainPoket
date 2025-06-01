using UnityEngine;

public class EV_ChangePlayerData : MonoBehaviour, I_KajiaControlls
{
    [Header("Hit Ground")]
    [SerializeField] private int changeHealthOnGround;
    [SerializeField] private float changePlayerSpeedOnGround;
    [SerializeField] private E_FreezeState changeFreezeStateOnGround;
    [SerializeField] private int changeOnGroundScore;

    [Header("Hit Player")]
    [SerializeField] private int changeHealthOnPlayer;
    [SerializeField] private float changePlayerSpeedOnPlayer;
    [SerializeField] private E_FreezeState changeFreezeStateOnPlayer;
    [SerializeField] private int changeOnPlayerScore;

    private B_player player;
    private GameManager gameManager;

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
        gameManager = kajia.gameManager;
        player = gameManager.player.GetComponent<B_player>();
    }

    public void FullfillAction()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangePlayerDataPlayer(collision.gameObject.GetComponent<I_HitObj>());
            EndObjAction();
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            ChangePlayerDataGround();
            EndObjAction();
        }
    }

    private void ChangePlayerDataGround()
    {
        player.MovemendFreezeState = changeFreezeStateOnGround;
        player.PlayerMovementSpeed += changePlayerSpeedOnGround;
        player.Hit(changeHealthOnGround);
        gameManager.Score += changeOnGroundScore;
    }
    private void ChangePlayerDataPlayer(I_HitObj i_HitObj)
    {
        player.MovemendFreezeState = changeFreezeStateOnPlayer;
        player.PlayerMovementSpeed += changePlayerSpeedOnPlayer;
        i_HitObj.Hit(changeHealthOnPlayer);
        gameManager.Score += changeOnPlayerScore;
    }
}
