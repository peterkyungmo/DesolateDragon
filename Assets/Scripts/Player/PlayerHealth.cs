using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private float hitTimer = 0.0f;
    private float hitInterval = 1f;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i=0; i<hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        hitTimer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && hitTimer > hitInterval)
        {
            // Collision
            hitTimer = 0f;
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            hearts[0].sprite = emptyHeart;
            Die();
        }
    }

    private void Die()
    {
        GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManager>().LoseGame();
        Destroy(gameObject);
    }
}
