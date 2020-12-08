using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Component Variables
    public Rigidbody2D rb;
    public Animator animator;
    #endregion

    #region Movement Variables
    public float moveSpeed = 5f;
    float dashTime = 0.25f;
    float dashInterval = 2f;
    private float dashTimer = 0f;
    float dashMultiplier = 4f;
    private float speedMultiplier = 1f;
    Vector2 movement;
    #endregion

    #region Movement Functions
    // Moves the player's rigidbody based on our movement variables
    private void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
    }
    #endregion

    #region Unity Functions

    private void Start()
    {
        animator = GetComponent<Animator>();
        dashTimer = dashInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        // Check for dash cooldown
        if (dashTimer > dashTime)
        {
            speedMultiplier = 1f;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.K) && dashTimer > dashInterval)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            dashTimer = 0f;

            speedMultiplier = dashMultiplier;
        }

        dashTimer += Time.deltaTime;

        // Set Animations
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }


        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // FixedUpdate is called on a fixed timer
    private void FixedUpdate()
    {
        // Execute Player Movement
        Move();
    }
    #endregion
}
