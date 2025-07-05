using UnityEngine;

public class IT_Umbrella : B_Item
{

    [SerializeField] private GameObject playerUmbrellaPrefab;
    private GameObject spawnedUmbrella = null;

    public override void HitPlayer(GameObject player)
    {
        print(player.name);
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

    public override void EndObjAction()
    {
        gameObject.SetActive(false);
    }
    public override void KillObj()
    {
        if (spawnedUmbrella != null)
        {
            spawnedUmbrella.SetActive(false);
        }

        gameObject.SetActive(false);
    }

}
