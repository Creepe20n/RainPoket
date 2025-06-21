using UnityEngine;

public class IT_spwnd_IBOEimer : MonoBehaviour
{
    [Tooltip("the Score that gets multiplied at the End by x")]
    [SerializeField] private int baseScore;
    [SerializeField] private float lifeTime = 1;
    [HideInInspector] public GameManager gameManager;
    private float activeLifeTime = 0;
    private int countTrigger = 0;

    void OnEnable()
    {
        countTrigger = 0;
        activeLifeTime = 0;
    }

    void Update()
    {
        if (activeLifeTime >= lifeTime)
        {
            gameManager.Score += baseScore * countTrigger;   
            gameObject.SetActive(false);
            return;
        }
        activeLifeTime += Time.deltaTime * GameTime.Instance.EventTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Untagged"))
        {
            return;
        }

        countTrigger++;
        collision.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        Destroy(gameObject);
    }
}
