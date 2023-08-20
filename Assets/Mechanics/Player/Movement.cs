using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{   
    [SerializeField]private float Speed;// Player speed
    [SerializeField]private float RunSpeed;// Player speed
    private float OldSpeed; // Store the old speed to be able to update it after the sprint ends.
    private float ScaleX; // Use it to rotate the character correctly towards the left or right axis when the player moves.
    private Rigidbody2D PlayerRigidbody; // Player Rigidbody
    private Vector2 moveDirection; // Store the desired movement direction in a two-dimensional space horizontally or vertically.
    private Animator Animator; // Player Animator
    private bool isMoving = false; // Movement status
    private bool isRunnimg = false; // Running status

    private void Start()
    {   // Initialization
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        OldSpeed = Speed;
        ScaleX = transform.localScale.x;
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleAnimation();

    }
    public void HandleMovement()
    {
        isRunnimg = Input.GetKey(KeyCode.LeftShift);
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        // Move the game object's Rigidbody component in a physics-friendly way.
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + moveDirection.normalized * Speed * Time.fixedDeltaTime);

        // Check if it goes left or right and rotate the sprite to be on the correct side.
        if (moveDirection.x > 0)
        {
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(ScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection.x < 0)
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.localScale =new Vector3(-ScaleX, transform.localScale.y, transform.localScale.z);
        }

        // Check states
        if (moveDirection == Vector2.zero)
            isMoving = false;
        else
            isMoving = true;
        if (isRunnimg)
            Speed = RunSpeed;
        else
            Speed = OldSpeed;
    }
    void HandleAnimation()
    {   if(isMoving)
            Animator.SetBool("walk", true);
        else
            Animator.SetBool("walk", false);
        if (isRunnimg&&isMoving)
        {
            Animator.SetBool("run", true);
        }
        else
        {
            Animator.SetBool("run", false);
        }
    }
}
