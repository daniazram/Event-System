using UnityEngine;

public class MuzzlePositionAdjuster : MonoBehaviour
{
    [SerializeField]
    private Vector3[] muzzlePositions;

    public void OnProne(object[] data)
    {
        var proned = (bool)data[0];
        transform.localPosition = muzzlePositions[proned ? 1 : 0];
    }
}
