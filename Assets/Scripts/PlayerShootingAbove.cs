using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAbove : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootInterval = 2f;
    float shootTimer = 0f;
    public bool defeated_fire_boss = true;

    public float bulletForce = 5.0f;
    void Start()
    {
        shootTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (defeated_fire_boss && Input.GetKeyDown(KeyCode.L) && shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootInterval;
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
        // Logic to activate shooting
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
