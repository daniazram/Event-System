using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private static Pool instance;

    [SerializeField]
    private int size;
    [SerializeField]
    private GameObject bulletPrefab;
    private List<Bullet> bullets;

    public static Pool Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Pool>();

            return instance;
        }
    }

    void Awake()
    {
        bullets = new List<Bullet>();
        Setup();
    }

    void Setup()
    {
        var parent = new GameObject("Bullets");
        parent.transform.SetParent(transform);

        for (int i = 0; i < size; i++)
        {
            var bullet = Instantiate(bulletPrefab, parent.transform).GetComponent<Bullet>();
            bullet.name = "Bullet# " + i;
            bullet.gameObject.SetActive(false);

            bullets.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        foreach (var bullet in bullets)
            if (!bullet.gameObject.activeSelf)
            { bullet.gameObject.SetActive(true); return bullet; }

        return null;
    }
}
