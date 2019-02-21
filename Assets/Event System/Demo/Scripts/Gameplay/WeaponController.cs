using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private float rateOfFire;
    [SerializeField]
    private Transform muzzle;
    private float timeSinceLastShot;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot(object[] data)
    {
        if (timeSinceLastShot < rateOfFire)
            return;

        var state = (bool)data[0];
        if (!state)
            return;

        timeSinceLastShot = 0;
        var bullet = Pool.Instance.GetBullet();

        if(bullet != null)
            bullet.SetupAndMove(muzzle);
    }
}
