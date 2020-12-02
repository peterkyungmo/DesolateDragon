using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    Vector2 direction;
    Vector3 direction3D;
    float x_input;
    float y_input;
    public Transform attackHB;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        // Change the hit box location relative to the player transform according to the player direction.
        SetHitBox();
    }

    void SetHitBox()
    {
        // Set Right Direction
        if (x_input > 0)
        {
            direction = Vector2.right;
            // Upright Direction
            if (y_input > 0)
            {
                direction.y = Vector2.up.y;
            }
            else if (y_input < 0)
            {
                direction.y = Vector2.down.y;
            }
        }
        // Set Left Direction
        else if (x_input < 0)
        {
            direction = Vector2.left;
            // Upleft Direction
            if (y_input > 0)
            {
                direction.y = Vector2.up.y;
            }
            else if (y_input < 0)
            {
                direction.y = Vector2.down.y;
            }
        }
        // Set Up Direction
        else if (y_input > 0)
        {
            direction = Vector2.up;
        }
        else if (y_input < 0)
        {
            direction = Vector2.down;
        }
        direction3D = direction;
        attackHB.position = playerTransform.position + direction3D;
    }
}
