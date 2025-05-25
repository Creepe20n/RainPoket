using UnityEngine;
[ExecuteInEditMode]
public class PlayerBarria : MonoBehaviour
{
    
    public enum Site
    {
        Left,Right
    }

    Camera cam;

    public Site _site;

    float _radius;

    private void Update()
    {
        cam = Camera.main;
        _radius = GetComponent<SpriteRenderer>().bounds.extents.x;
        

        if (_site == Site.Left)
        {
            transform.position = new Vector2(cam.transform.position.x - (cam.aspect * cam.orthographicSize) - _radius, cam.transform.position.y);
        }
        else { transform.position = new Vector2(cam.transform.position.x  +(cam.aspect*cam.orthographicSize) + _radius, cam.transform.position.y); }
    }

}
