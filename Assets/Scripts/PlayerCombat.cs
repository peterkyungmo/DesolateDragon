using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Animator animator;
    public Transform attackHitBox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    public float attackSpeed = 1.0f;
    private float nextAttack = 0.0f;
    public GameObject explosionObj;


    // Update is called once per frame
    void Update()
    {
        // Check for attack input
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextAttack)
        {
            //If the player attacked, reset the nextAttack time to a new point in the future
            nextAttack = Time.time + attackSpeed;

            Attack();
        }
    }

    void Attack()
    {
        // Play an attack animation
        Instantiate(explosionObj, attackHitBox.position, transform.rotation); //Temporary explosion animation
        //animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackHitBox == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }
}
