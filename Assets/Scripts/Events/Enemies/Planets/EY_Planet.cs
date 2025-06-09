using UnityEngine;

public class EY_Planet : B_Item
{
    [SerializeField] float gravityRadius = 1;
    [SerializeField] float gravitySpeed = 1;
    [SerializeField] int damage = -1;
    [SerializeField] Sprite icePlanet;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool freeze => spriteRenderer.sprite == icePlanet;
    [SerializeField] private float freezeTime = 1;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        
        if (collision.gameObject.CompareTag("EY_Snowflake"))
        {
            spriteRenderer.sprite = icePlanet;
            collision.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, gravityRadius);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].attachedRigidbody.bodyType == RigidbodyType2D.Static)
            {
                continue;
            }
            if (objects[i].gameObject.CompareTag(gameObject.tag) && Vector2.Distance(transform.position, objects[i].gameObject.transform.position) < 0.5)
                continue;

            Vector2 direction = transform.position - objects[i].transform.position;
            direction.Normalize();

            objects[i].transform.Translate(0.1f * GameTime.Instance.EventTime * gravitySpeed * Time.deltaTime * direction);
        }
    }

    public override void HitPlayer(GameObject player = null)
    {
        I_HitObj i_HitObj = null;
        Freezeble freezeble = null;
        try
        {
            i_HitObj = player.GetComponent<I_HitObj>();
            i_HitObj.Hit(damage);

            if (!freeze)
                return;

            freezeble = player.GetComponent<Freezeble>();
            freezeble.Freeze(freezeTime);
        }
        catch { }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
#endif
}
