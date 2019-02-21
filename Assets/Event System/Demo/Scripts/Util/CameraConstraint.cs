using UnityEngine;

public class CameraConstraint : MonoBehaviour
{
    [SerializeField]
    private Vector2 fovLimits;
    [SerializeField]
    private Vector2 baseResolution;
    
    private float baseRatio;
    private Camera cam;

    private Camera Cam
    {
        get
        {
            if (cam == null)
                cam = GetComponent<Camera>();

            if (cam == null)
                cam = Camera.main;

            return cam;
        }
    }

    private void Awake()
    {
        baseRatio = baseResolution.x / baseResolution.y;

        AdjustFov();
    }

    private void Update()
    {
        #if (UNITY_EDITOR)
            AdjustFov();
        #endif
    }

    void AdjustFov()
    {
        var currentRatio = (float)Screen.width / (float)Screen.height;
        var diffPercentage = Mathf.Clamp01(Mathf.Abs(currentRatio - baseRatio / baseRatio));
        
        Cam.orthographicSize = Mathf.Lerp(fovLimits.x, fovLimits.y, diffPercentage);
    }
}
