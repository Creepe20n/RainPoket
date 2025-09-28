using UnityEngine;

public class SyncUI : MonoBehaviour
{
    [SerializeField] private RectTransform target; // dein animiertes Objekt
    private RectTransform self;

    void Awake()
    {
        self = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1:1 Übernahme von Position, Rotation und Scale
        self.position = target.position;
        self.rotation = target.rotation;
        self.localScale = target.localScale;
    }
}
