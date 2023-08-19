using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{   
    [SerializeField]private float Speed;// Player speed
    [SerializeField]private float RunSpeed;// Player speed
    private float OldSpeed;
    private Vector3 OldScale;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator Animator;
    private bool isMoving = false;
    private bool isRunnimg = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        OldSpeed = Speed;
        OldScale = transform.localScale;
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
        rb.MovePosition(rb.position + moveDirection.normalized * Speed * Time.fixedDeltaTime);

        // Check if it goes left or right and rotate the sprite to be on the correct side.
        if (moveDirection.x > 0)
        {
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = OldScale;
        }
        else if (moveDirection.x < 0)
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.localScale =new Vector3(-0.64f, transform.localScale.y, transform.localScale.z);
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
