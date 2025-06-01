using UnityEngine;

public class IT_Umbrella : MonoBehaviour, I_KajiaControlls
{
    private B_player b_Player;
    [SerializeField] private GameObject playerUmbrellaPrefab;
    private GameObject spawnedUmbrella;
    public void EndObjAction()
    {

    }

    public void FullfillAction()
    {
        if (spawnedUmbrella == null)
        {
            spawnedUmbrella = Instantiate(playerUmbrellaPrefab, b_Player.transform);
        }
        spawnedUmbrella.transform.localPosition = Vector2.zero;
        spawnedUmbrella.SetActive(true);
    }

    public void KillObj()
    {
        gameObject.SetActive(false);
    }

    public void SetKajiaValues(KajiaSystem kajia)
    {
        if(b_Player == null)
            b_Player = kajia.gameManager.player.GetComponent<B_player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FullfillAction();
            KillObj();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            KillObj();
        }
    }
    
}
