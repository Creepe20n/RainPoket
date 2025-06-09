using UnityEngine;

public class IT_Umbrella : MonoBehaviour, I_KajiaControlls
{
    private B_player b_Player;
    [SerializeField] private GameObject playerUmbrellaPrefab;
    private GameObject spawnedUmbrella;
    public void EndObjAction()
    {
        gameObject.SetActive(false);
    }

    public void FullfillAction(GameObject player)
    {

        if (spawnedUmbrella == null || spawnedUmbrella.activeSelf)
        {
            spawnedUmbrella = Instantiate(playerUmbrellaPrefab, player.transform);
        }

        SpriteRenderer umbrellaSR = spawnedUmbrella.GetComponent<SpriteRenderer>();

        spawnedUmbrella.transform.SetParent(player.transform);

        //Scale the umbrella to fit the player
        float xScale = player.GetComponent<SpriteRenderer>().bounds.extents.x + 0.2f / umbrellaSR.bounds.extents.x;
        spawnedUmbrella.transform.localScale = new Vector3(xScale, xScale, 0);

        //Position the umbrella above the player
        spawnedUmbrella.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y + umbrellaSR.bounds.extents.y,
            player.transform.position.z
        );

        spawnedUmbrella.SetActive(true);
    }

    public void FullfillAction()
    {
        throw new System.NotImplementedException();
    }

    public void KillObj()
    {
        if (spawnedUmbrella != null)
        {
            spawnedUmbrella.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    public void SetKajiaValues(KajiaSystem kajia)
    {
        if (b_Player == null)
            b_Player = kajia.gameManager.player.GetComponent<B_player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FullfillAction(collision.gameObject);
            EndObjAction();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            EndObjAction();
        }
    }

}
