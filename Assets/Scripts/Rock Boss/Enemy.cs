using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    public float moveInterval = 1f;
    public float moveStopTime = 1 / 3;
    public int movePerAttack = 3;
    float moveTimer;
    bool changeDirection = true;
    bool isMoving;
    #endregion

    #region Attack_variables
    public float attackDuration;
    private float attackspeed;
    public float attackdamage;
    float attackTimer;
    bool isAttacking;
    #endregion

    #region Physics_components
    protected Rigidbody2D EnemyRB;
    #endregion

    #region Animation_component
    Animator anim;
    #endregion

    #region Targeting_varaibles
    public Transform player;
    #endregion


    #region Unity_functions
    // runs once on creation
    protected void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();

        moveTimer = attackDuration;

        anim = GetComponent<Animator>();

        attackspeed = movePerAttack * (moveInterval + moveStopTime) - moveStopTime + attackDuration;

        attackTimer = attackspeed;

        //HPSlider.value = currHealth / maxhealth;

        //Debug.Log("Attack speed is " + attackspeed.ToString() + ".");

        anim.SetFloat("DirX", 1f);
        anim.SetFloat("DirY", 0f);
        
    }

    //runs once every frame
    protected void Update()
    {
        //check if we know where the player is
        if (player == null)
        {
            return;
        }

        Move();

        if (attackTimer < 0)
        {
            Attack();
            anim.SetTrigger("AttackTrig");
            attackTimer += attackspeed;
        }
        else
        {
            attackTimer -= Time.deltaTime;
            //Debug.Log("Attack timer is now " + attackTimer.ToString() + ".");
        }
    }
    #endregion

    #region Movement_function
    protected void Move()
    {

        Vector2 direction = player.position - transform.position;
        direction = Round(direction);

        if (moveTimer <= 0)
        {
            if (changeDirection == true)
            {
                
                anim.SetFloat("DirX", direction.normalized.x);
                anim.SetFloat("DirY", direction.normalized.y);
                anim.SetBool("Moving", true);
                
                EnemyRB.velocity = direction.normalized * movespeed;
                changeDirection = false;
            }

            moveTimer -= Time.deltaTime;
            if (moveTimer <= -moveInterval)
            {
                moveTimer += moveStopTime + moveInterval;
                changeDirection = true;
                anim.SetBool("Moving", false);
                EnemyRB.velocity = direction * 0;
                //Debug.Log("moveTimer is now " + moveTimer.ToString());
            }
        }
        else
        {
            anim.SetBool("Moving", false);
            anim.SetFloat("DirX", direction.normalized.x);
            anim.SetFloat("DirY", direction.normalized.y);
            EnemyRB.velocity = direction.normalized * 1/2f;
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0)
            {
                anim.SetBool("Moving", true);
            }
        }
    }

    private Vector2 Round(Vector2 vector)
    {
        float absX = Mathf.Abs(vector.x);
        float absY = Mathf.Abs(vector.y);

        if (absX >= 2.42f * absY)
        {
            vector.y = 0f;
        } 
        else if (absY >= 2.42f * absX)
        {
            vector.x = 0f;
        }
        else if (vector.x * vector.y >=0)
        {
            vector.x = vector.y;
        }
        else
        {
            vector.x = -1f * vector.y;
        }

        return vector;  
    }
    #endregion

    #region Attack_function
    public void Attack()
    {
        FindObjectOfType<AudioManager>().Play("HedgeAttack");
        //Debug.Log("The Boss attacks. It takes " + attackDuration + " time.");
        moveTimer += attackDuration - moveStopTime;
        //Debug.Log("Attack speed is " + attackspeed.ToString() + ".");

    }
    #endregion


}