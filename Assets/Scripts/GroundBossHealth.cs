using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBossHealth : MonoBehaviour
{
    public float maxhealth;
    public float currHealth;
    public GameObject portal;
    public Transform portalSpawn;

    public void TakeDamage(float value)
    {
        FindObjectOfType<AudioManager>().Play("HedgeHurt");
        Debug.Log("No bird sound");
        currHealth -= value;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Instantiate(portal, portalSpawn.position, portalSpawn.rotation);
        Destroy(this.gameObject);
    }
}
