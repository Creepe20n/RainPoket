using UnityEngine;
/// <summary>
/// To Get the position of some body parts based of the current sprite.
/// Also lets you set objects on bodyparts 
/// </summary>
public class EntitiyBody : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameObject _headSlot;
    public GameObject HeadSlot
    {
        get
        {
            return _headSlot;
        }
        set
        {
            _headSlot = value;
            _headSlot.transform.SetParent(gameObject.transform);
        }
    }


    /// <summary>
    /// returns true when headSlot isnt null and false otherwise
    /// </summary>
    public bool HeadSlotState => HeadSlot != null;
    Sprite lastSprite;
    Vector2 _lastHeadCenterPos;
    public Vector2 HeadCenterPos
    {
        private set { }
        get
        {
            if (lastSprite == spriteRenderer.sprite)
                return _lastHeadCenterPos;

            _lastHeadCenterPos = new Vector2(
                transform.position.x,
                transform.position.y + spriteRenderer.bounds.extents.y
            );

            return _lastHeadCenterPos;
        }
    }
    
}
