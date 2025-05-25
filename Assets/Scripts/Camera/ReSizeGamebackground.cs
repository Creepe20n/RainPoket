using UnityEngine;
using PoketAPI.Camera;
using PoketAPI.Convert;
[ExecuteAlways]
public class ReSizeGamebackground : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    float cameraHeigth;
    void Update()
    {
        if (spriteRenderer == null)
            return;

        transform.localScale = Vector3.one;

        cameraHeigth = CameraData.GetHight();
        float objectHeightExtend = spriteRenderer.bounds.extents.y;

        float distanceBetweenCamAndBack = ConvertPosition.Y_Distance(
            gameObject.transform.position.y,
            Camera.main.gameObject.transform.position.y + cameraHeigth / 2
        );

        float newScale = distanceBetweenCamAndBack / objectHeightExtend;

        transform.localScale = new Vector3(newScale, newScale, 0);
        
    }
}
