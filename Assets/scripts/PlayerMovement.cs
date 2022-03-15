using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;

    public Rigidbody2D mc;

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = 8f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed = 5f;
        }
        
    }

    void FixedUpdate()
    {
        mc.MovePosition(mc.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
