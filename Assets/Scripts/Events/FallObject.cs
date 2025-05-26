using UnityEngine;

public class FallObject : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 1;
    [SerializeField] private ParticleSystem disableParticlePrefab;
    private ParticleSystem disableParticle = null;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime * GameTime.Instance.GameRunTime);
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
