using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHittingEnemy : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<BossHealth>().TakeDamage(1);
            }
            Destroy(gameObject);
            Destroy(effect, 5f);
        }
    }
}
