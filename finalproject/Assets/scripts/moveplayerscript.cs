using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveplayerscript : MonoBehaviour { // Variables set in the inspector

    public string playertype;
    public float WalkSpeed = 3;
    public float RunSpeed = 5;
    public float JumpForce = 300;
    Vector2 gdirection;
    AudioSource Jump;
    

    // Booleans used to coordinate with the animator's state machine

    bool Running;
    bool Moving;
    bool Grounded;
    bool Falling;
    // References to other components (can be from other game objects!)

    Animator Animator;

    Rigidbody2D RigidBody2D;
    public float moveSpeed;


    void Start()

    {
        gameObject.name = "player";
        // Get references to other components and game objects

        RigidBody2D = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();



    }
    void Update()
    {
        if (playertype == "skaterboy")
        {
            if (RigidBody2D.velocity.magnitude< 7)
            {
                RigidBody2D.AddForce(Vector2.right * 10);
            }
            
        }

        if (playertype == "iceman")
        {
            MoveCharacter();
            CheckFalling();
            CheckGrounded();

            // Update animator's variables

            Animator.SetBool("isRunning", Running);
            Animator.SetBool("isMoving", Moving);
            Animator.SetBool("isGrounded", Grounded);
            Animator.SetBool("isFalling", Falling);
        }
        else if (playertype == "skaterboy")
        {
           
            CheckFalling();
            CheckGrounded();
            MoveCharacter();
            Animator.SetBool("isMoving", true);
            Animator.SetBool("isSlow", Skslowing());
        }






    }


    private void MoveCharacter()

    {

        Running = Input.GetButton("run");  //returns true or false if pressed.
                                           // Determine movement speed
        moveSpeed = Running ? RunSpeed : WalkSpeed;
        //Change value    (  IF   )    TRUE    :   FALSE   ;
        // Check for movement
        Moving = Input.GetButton("Horizontal"); //returns true or false if pressed.
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        if (playertype == "iceman")
        {
            FaceDirection(new Vector2(direction, 0));
        }
       
        if (playertype == "skaterboy")
        {
            SkFaceDirection(new Vector2(3, 0));
            JumpForce = 300;

        }
            


        // Check if we can jump
        if (Grounded && Input.GetButtonDown("Jump") && Moving)
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce * 1.5f);
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
        }
        else if (Grounded && Input.GetButtonDown("Jump"))
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce);
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
        }
    }
    private void CheckFalling()
    {
        Falling = RigidBody2D.velocity.y < 0.0f;

    }

    private void CheckGrounded()

    {

        Grounded = RigidBody2D.velocity.y == 0.0f;

    }




    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;
        // Flip the sprite (NOTE: Vector3.forward is positive Z in 3D. The Sprite is on XY plane!)
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
        gdirection = direction;

    }
    private void SkFaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;
       
        gdirection = direction;

    }
    public Vector2 GetFaceDirection()
    {
        return gdirection;
    }
    bool Skslowing()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}








/*
        
         float horizontal = Input.GetAxisRaw("Horizontal");
         transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime*3;
         float vertical = Input.GetAxisRaw("Vertical");
         transform.position += new Vector3(0, vertical, 0) * Time.deltaTime*5;
         float horizontalR = Input.GetAxisRaw("HorizantalRun");
         transform.position += new Vector3(horizontalR, 0, 0) * Time.deltaTime * 5;
         float verticalR = Input.GetAxisRaw("VerticalRun");
         transform.position += new Vector3(0, verticalR, 0) * Time.deltaTime * 7;
         * 
         * 
         * 
         * */

// Check if we are running or not

// TODO: Check if the player wants Mario to run (see input manager)

//       and set the value of "Running" accordingly

//       Use Input and the intellisence