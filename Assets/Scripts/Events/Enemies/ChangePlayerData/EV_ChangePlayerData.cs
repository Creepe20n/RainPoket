using UnityEngine;

public class EV_ChangePlayerData : B_Item, I_ScoreData
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

    public override void HitPlayer(GameObject player = null)
    {
        B_Entities b_Entities = player.GetComponent<B_Entities>();
        b_Entities.E_FreezeState = changeFreezeStateOnPlayer;
        b_Entities.MovementSpeed += changePlayerSpeedOnPlayer;
        b_Entities.Hit(changeHealthOnPlayer);
        kajiaSystem.gameManager.Score += changeOnPlayerScore;
    }
    public override void HitGround()
    {
        b_Player.E_FreezeState = changeFreezeStateOnGround;
        b_Player.MovementSpeed += changePlayerSpeedOnGround;
        b_Player.Hit(changeHealthOnGround);
        kajiaSystem.gameManager.Score += changeOnGroundScore;
    }

    public int GetPlayerScore()
    {
        return changeOnPlayerScore;
    }

    public int GetGroundScore()
    {
        return changeOnGroundScore;
    }
}
