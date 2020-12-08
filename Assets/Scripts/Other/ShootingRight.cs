using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRight : MonoBehaviour
{
    Animator anim;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5.0f;
    void Start()
    {
        // Calls Shoot every 2 seconds after instantiated for 3 seconds
        InvokeRepeating("Shoot", 3.0f, 2.0f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Logic to activate shooting

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        anim.SetTrigger("AttackTrig");
    }
}
