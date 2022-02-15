using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float Speed = 5f;
    public float JumpForce = 7.5f;

    private float HorizontalMovement = 0f;
    public int Facing = 1;

    public Rigidbody2D MyRigidbody2D;
    public CircleCollider2D Feet;

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") 
            && Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                MyRigidbody2D.AddForce(new Vector2(0f, JumpForce), 
                    ForceMode2D.Impulse);
            }
    }

    void FixedUpdate()
    {
        MyRigidbody2D.velocity = new Vector2(HorizontalMovement * Speed,
            MyRigidbody2D.velocity.y);
    }
}
