using UnityEngine;

public class BoundToScreen : MonoBehaviour
{
    [SerializeField]
    private Vector2 bounds = new Vector2(0, 1);
    private Camera cam;
    private Camera Cam
    {
        get
        {
            if (cam == null)
                cam = Camera.main;

            return cam;
        }
    }

    private Vector3 ViewportPosition
    {
        get
        {
            var pos = Cam.WorldToViewportPoint(transform.position);
            
            return pos;
        }
    }

    public bool IsOutOfBounds(bool goingLeft)
    {
        if (goingLeft)
            return ViewportPosition.x < bounds.x;
        else
            return ViewportPosition.x > bounds.y;
    }
}
