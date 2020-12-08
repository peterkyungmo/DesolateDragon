using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxhealth;
    public float currHealth;

    public void TakeDamage(float value)
    {
        currHealth -= value;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
