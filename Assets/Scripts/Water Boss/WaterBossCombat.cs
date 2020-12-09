using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBossCombat : MonoBehaviour
{
    public Transform attackHitBoxNorth;
    public Transform attackHitBoxSouth;
    public Transform attackHitBoxEast;
    public Transform attackHitBoxWest;

    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public int attackDamage = 1;
    public float attackSpeed = 5.0f;
    private float nextAttack = 0.0f;
    public GameObject tideNorth;
    public GameObject tideSouth;
    public GameObject tideEast;
    public GameObject tideWest;

    // Update is called once per frame
    void Update()
    {
        // TODO: Add timer logic
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackSpeed;
            Attack();
        }
    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("OctopusAttack");
        // Play attack animations
        Instantiate(tideNorth, attackHitBoxNorth.position, transform.rotation);
        Instantiate(tideSouth, attackHitBoxSouth.position, transform.rotation);
        Instantiate(tideEast, attackHitBoxEast.position, transform.rotation);
        Instantiate(tideWest, attackHitBoxWest.position, transform.rotation);

        // Detect player in range of north attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackHitBoxNorth.position, attackRange, playerLayers);

        // Damage Player
        foreach(Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage();
        }

        // Detect player in range of south attack
        hitPlayers = Physics2D.OverlapCircleAll(attackHitBoxSouth.position, attackRange, playerLayers);

        // Damage Player
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage();
        }

        // Detect player in range of east attack
        hitPlayers = Physics2D.OverlapCircleAll(attackHitBoxEast.position, attackRange, playerLayers);

        // Damage Player
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage();
        }

        // Detect player in range of west attack
        hitPlayers = Physics2D.OverlapCircleAll(attackHitBoxWest.position, attackRange, playerLayers);

        // Damage Player
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackHitBoxNorth == null || attackHitBoxSouth == null || attackHitBoxEast == null || attackHitBoxWest == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackHitBoxNorth.position, attackRange);
        Gizmos.DrawWireSphere(attackHitBoxSouth.position, attackRange);
        Gizmos.DrawWireSphere(attackHitBoxEast.position, attackRange);
        Gizmos.DrawWireSphere(attackHitBoxWest.position, attackRange);
    }
}
