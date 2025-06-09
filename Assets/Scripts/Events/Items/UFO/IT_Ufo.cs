using UnityEngine;

[RequireComponent(typeof(FallObject))]
public class IT_Ufo : B_Item
{
    public GameObject ufoPrefab;
    private GameObject spawnedUfo;

    public override void HitPlayer(GameObject player = null)
    {
        if (spawnedUfo == null || spawnedUfo.activeSelf)
        {
            spawnedUfo = Instantiate(ufoPrefab, player.transform.position, Quaternion.identity);
            spawnedUfo.GetComponent<IT_UfoMove>().gameManager = kajiaSystem.gameManager;
        }

        spawnedUfo.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y + 1.0f, // Adjust height as needed
            player.transform.position.z
        );
        spawnedUfo.SetActive(true);
    }
}
