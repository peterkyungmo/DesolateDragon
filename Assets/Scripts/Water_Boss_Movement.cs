using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Boss_Movement : MonoBehaviour
{
    protected Rigidbody2D boss2RB;

    #region Movement_variables
    public float movespeed = 3f;
    public float moveinterval = 1f;
    float movetimer = 0.5f;
    float speedmultiplier = 1f;
    Vector2 movement;
    #endregion

    #region Animation_component
    Animator anim;
    #endregion

    #region Targeting_varaibles
    public Transform player;
    #endregion

    #region Unity_functions
    // Start is called before the first frame update
    protected void Awake()
    {
        boss2RB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.SetFloat("DirX", 0f);
        anim.SetFloat("DirY", -1f);
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    public float RandomNumber()
    {
        float random = Random.Range(0.5f, 1.5f);
        return random;
    }
    #endregion

    #region Movement_functions
    protected void Move()
    {
        if (movetimer <= 0)
        {
            speedmultiplier = RandomNumber();
            movetimer = moveinterval;
        } else
        {
            movetimer -= Time.deltaTime;
        }

        if (player != null)
        {
            movement = player.position - transform.position;
            anim.SetFloat("DirX", movement.x);
            anim.SetFloat("DirY", movement.y);
        }

        boss2RB.velocity = movement.normalized * movespeed * speedmultiplier;

    }
    #endregion
}
