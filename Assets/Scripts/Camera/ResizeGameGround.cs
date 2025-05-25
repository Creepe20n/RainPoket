using PoketAPI.Camera;
using PoketAPI.Convert;
using UnityEngine;

[ExecuteAlways]
public class ResizeGameGround : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float cameraWidth;

    private void Update()
    {
        if (spriteRenderer == null)
            return;

        if (cameraWidth == CameraData.GetWidth())
            return;

        transform.localScale = Vector3.one;

        cameraWidth = CameraData.GetWidth();
        float objectWidthExtend = spriteRenderer.bounds.extents.x;

        float distanceBetweenCamAndBack = ConvertPosition.X_Distance(
            gameObject.transform.position.x,
            Camera.main.gameObject.transform.position.x + cameraWidth / 2
        );

        float newScale = distanceBetweenCamAndBack / objectWidthExtend;

        transform.localScale = new Vector3(newScale, newScale, 0);

        transform.position = new Vector3(0, (Camera.main.transform.position.y - CameraData.GetHight()/2)+spriteRenderer.bounds.extents.y, 0);
    }
}
