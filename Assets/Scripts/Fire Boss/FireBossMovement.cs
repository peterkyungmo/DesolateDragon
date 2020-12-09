using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossMovement : MonoBehaviour
{
    protected Rigidbody2D boss2RB;

    #region Movement_variables
    public float movespeed = 4f;
    public float moveInterval = 1f;
    float moveTimer;
    Vector2 movement;

    #endregion

    // Start is called before the first frame update
    protected void Awake()
    {
        boss2RB = GetComponent<Rigidbody2D>();
        moveTimer = moveInterval;
        FindObjectOfType<AudioManager>().Play("BirdStart");
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    public Vector2 RandomUnitVector()
    {
        float random = Random.Range(0f, 359.9f);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }

    protected void Move()
    {

        if (moveTimer <= 0)
        {
            movement = RandomUnitVector();
            moveTimer = moveInterval;
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }

        boss2RB.velocity = movement * movespeed;

    }
}
