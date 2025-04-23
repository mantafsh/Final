using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //character controller component
    private CharacterController controller;
    //movement input
    private Vector3 movementInput;
    //velocity
    private Vector3 velocity;
    public float walkSpeed = 5;
    //gravity 
    private float gravity = -9.81f;
    //just in case, even though there's no jumping
    public bool isGrounded;
    //thats really it i think
    //make the character rotate to the cursor? maybe?
    //not much here to do 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //zInput gets player's w or s input which is -1 or 1
        float zInput = Input.GetAxis("Vertical");
        //for character controller just call velocity
        velocity = transform.forward * zInput * walkSpeed +
        transform.right * horizontalInput * walkSpeed + Vector3.up *
        velocity.y;
        //calling 
        MovePlayer();
    }

    private void MovePlayer() 
    {
        isGrounded = controller.isGrounded;
        //if the player is on the ground reset gravity
        if (isGrounded)
        {
            //small downward force to keep us grounded
            velocity.y = -1;
            
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        //move player on the x and z
        controller.Move(movementInput * walkSpeed *
        Time.deltaTime);
        //apply vertical movement (gravity and jumping)
        controller.Move(velocity * Time.deltaTime);
    }
}
