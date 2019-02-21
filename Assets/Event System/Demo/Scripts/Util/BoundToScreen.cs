using UnityEngine;

public class BoundToScreen : MonoBehaviour
{
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
            return ViewportPosition.x < 0;
        else
            return ViewportPosition.x > 1;
    }
}
