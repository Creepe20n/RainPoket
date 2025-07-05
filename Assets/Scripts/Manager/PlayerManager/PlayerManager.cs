using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int activePlayerNum = 0;
    [SerializeField] private int activeGravestoneNum = 0;
    [SerializeField] private List<GameObject> players = new();
    [SerializeField] private List<GameObject> graveStones = new();
    [SerializeField] private GameObject groundObject;
    [SerializeField] private GameManager gameManager;
    private GameObject activePlayerObj;

    void Start()
    {
        PlacePlayer(0);
    }

    private void PlacePlayer(int plyrNummber)
    {
        float plyrY2 = players[plyrNummber].GetComponent<SpriteRenderer>().bounds.extents.y;
        float groundY2 = groundObject.GetComponent<SpriteRenderer>().bounds.extents.y;

        Vector2 plyrSpawnPos = new Vector2(groundObject.transform.position.x, groundObject.transform.position.y + groundY2 + plyrY2);

        if (activePlayerObj != null)
            Destroy(activePlayerObj);

        activePlayerObj = Instantiate(players[plyrNummber], plyrSpawnPos, Quaternion.identity);
        activePlayerObj.GetComponent<B_player>().GraveStone = graveStones[activeGravestoneNum];

        gameManager.player = activePlayerObj;
        activePlayerNum = plyrNummber;
    }

}
