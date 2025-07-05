using UnityEngine;

public class PK_SpeedPlayerUp : B_ID, I_KajiaControlls
{
    [SerializeField] float changePlayerSpeed;
    private B_player b_Player = null;
    public void EndObjAction()
    {
        KillObj();
    }

    public void FullfillAction()
    {
        b_Player.MovementSpeed += changePlayerSpeed; 
    }

    public void KillObj()
    {
        gameObject.SetActive(false);
    }

    public void SetKajiaValues(KajiaSystem kajia)
    {
        if(b_Player == null)
            b_Player = kajia.gameManager.player.GetComponent<B_player>();

        FullfillAction();
    }
}
