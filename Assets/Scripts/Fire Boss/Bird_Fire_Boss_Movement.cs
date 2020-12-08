using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Fire_Boss_Movement : MonoBehaviour
{
    protected Rigidbody2D boss2RB;

    #region Movement_variables
    public float movespeed = 3f;
    public float moveInterval = 1f;
    public int chargeCD = 3;
    public float chargeMultiplier = 2f;
    int chargeCount;
    float moveTimer;
    float speedMultiplier = 1f;
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

        moveTimer = moveInterval;

        anim = GetComponent<Animator>();
        anim.SetFloat("DirX", 0f);
        anim.SetFloat("DirY", -1f);


        chargeCount = chargeCD;
        speedMultiplier = 1f;
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
    #endregion

    #region Movement_functions
    protected void Move()
    {

        if (moveTimer <= 0)
        {
            movement = RandomUnitVector();
            moveTimer = moveInterval;
            anim.SetFloat("DirX", movement.x);
            anim.SetFloat("DirY", movement.y);

            if (chargeCount == 0)
            {
                if (player != null)
                {
                    movement = player.position - transform.position;
                    anim.SetFloat("DirX", movement.x);
                    anim.SetFloat("DirY", movement.y);
                }
                chargeCount = chargeCD;
                speedMultiplier = chargeMultiplier;
                anim.SetBool("Moving", true);
            } else
            {
                chargeCount -= 1;
                speedMultiplier = 1f;
                anim.SetBool("Moving", false);
            }
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }

        boss2RB.velocity = movement.normalized * movespeed * speedMultiplier;

    }
    #endregion
}
