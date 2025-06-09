using UnityEngine;

public class ChangeSpriteByList : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    void OnEnable()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
