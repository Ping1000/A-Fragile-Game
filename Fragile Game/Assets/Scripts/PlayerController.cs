using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Controller structure and some segments from https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSmoothing = .1f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    Vector3 zeroVector = Vector3.zero;

    private Rigidbody2D rb;
    private Collider2D feetCollider;

    const float groundedRadius = .25f;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
   
        
    }

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref zeroVector, movementSmoothing);

        if (jump && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }

        // if sprite is moving in opposite direction that it is facing, call Flip()
    }

    private void Flip()
    {
        //flip the sprite
    }

    void IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundMask);
        grounded = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i]);
            if (colliders[i] != gameObject)
            {
                grounded = true;
            }
        }

        Debug.Log(grounded);

    }
}