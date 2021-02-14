using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Controller structure and some segments from https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
public class PlayerController : MonoBehaviour
{

    private Explodable _exp;

    [SerializeField] private float movementSmoothing = .1f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private LayerMask groundMask;

    [SerializeField]
    private float shatterThreshold;
    [SerializeField]
    private List<AudioClip> shatterSounds;
    [SerializeField]
    private List<AudioClip> jumpSounds;

    Vector3 zeroVector = Vector3.zero;

    public bool isFragile = true;

    private Rigidbody2D rb;
    private Collider2D feetCollider;
    private AudioSource src;

    const float groundedRadius = .25f;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<CircleCollider2D>();
        _exp = GetComponent<Explodable>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
   
        
    }

    public void Move(float move, bool jump, bool fall)
    {
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref zeroVector, movementSmoothing);

        if (jump && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
            src.clip = jumpSounds[Random.Range(0, jumpSounds.Count)];
            src.Play();
        }
        if (fall && rb.velocity.y > 0f)
        {
            //Debug.Log("Early Fall!");
            //rb.AddForce(new Vector2(0f, -.25f * jumpForce));
            rb.velocity = new Vector2(rb.velocity.x, 0f);//rb.velocity.y/10);

            //Debug.Log(rb.velocity);
        }

        // if sprite is moving in opposite direction that it is facing, call Flip()
    }

    private void Flip()
    {
        //flip the sprite
    }

    void IsGrounded()
    {
        grounded = false;
        foreach (Transform check in groundChecks)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(check.position, groundedRadius, groundMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                //Debug.Log(colliders[i]);
                if (colliders[i] != gameObject)
                {
                    grounded = true;
                }
            }
        }
        

        //Debug.Log(grounded);

    }

    void PlayerShatter()
    {
        AudioClip shatterSound = shatterSounds[Random.Range(0, shatterSounds.Count)];
        AudioSource.PlayClipAtPoint(shatterSound, gameObject.transform.position);
        _exp.explode();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If object is hit with enough velocity, break!
        if (isFragile)
        {
            //float kineticEnergy = .5f * collision.otherRigidbody.mass * collision.relativeVelocity.magnitude * collision.relativeVelocity.magnitude;

            //float kineticEnergy = collision.GetContact(0).normalImpulse;
            float kineticEnergy = 0f;
            for (int i = 0; i < collision.contactCount; i++)
            {
                float partial = collision.GetContact(i).normalImpulse;
                kineticEnergy += partial;
                //Debug.Log("PLAYER PARTIAL KE: " + partial);
            }
            Debug.Log("PLAYER KE: " + kineticEnergy);
            if (kineticEnergy >= shatterThreshold)
            {
                PlayerShatter();
            }
        }
    }
}