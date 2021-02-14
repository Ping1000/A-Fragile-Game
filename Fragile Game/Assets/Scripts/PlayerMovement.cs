// From Joseph Hocking's "Unity in Action" book.
// (It was how I relearned Unity a year ago for a project, I took the code 
// from my GitHub repo that I used while walking through the book.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float moveSpeed = 10f;
    float move = 0f;

    bool jump = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        characterController.Move(move, jump);
        jump = false;
    }
}
