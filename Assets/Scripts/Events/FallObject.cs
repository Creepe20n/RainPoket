using UnityEngine;

public class FallObject : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2;
    [SerializeField] private ParticleSystem disableParticlePrefab;
    private ParticleSystem disableParticle = null;

    void Update()
    {
        transform.Translate(fallSpeed * GameTime.Instance.EventTime * Time.deltaTime * Vector2.down);
    }

    void OnDisable()
    {
        if (disableParticle == null)
        {
            disableParticle = Instantiate(disableParticlePrefab, transform.position, Quaternion.identity);
        }
        disableParticle.transform.position = transform.position;
        disableParticle.Play();
    }
}
