using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    private Vector2 move;
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    private bool isRight = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
                
        move = new Vector2(horizontalInput, verticalInput);
        playerRb.velocity = move * speed * Time.fixedDeltaTime;
        MoveAnimation();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HealthManager.health -= 1;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            HealthManager.health -= 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
        {
            FuelManager.instance.IncreaseFuel();
            Destroy(other.gameObject);
          
        }       
    }
    void MoveAnimation()
{
    bool isMovingRight = playerRb.velocity.x > 0;
    bool isMovingLeft = playerRb.velocity.x < 0;
    bool isNotMovingHorizontal = playerRb.velocity.x == 0;
    bool isMovingUp = playerRb.velocity.y > 0;
    bool isMovingDown = playerRb.velocity.y < 0;
    bool isNotMovingVertical = playerRb.velocity.y == 0;



        if (isMovingRight)
        {
            isRight = true;
        }
        else if(isMovingLeft)
        {
            isRight = false; 
        }
        
        switch (true)
    {
        case bool _ when isMovingRight || (isMovingUp && isRight) || (isMovingDown && isRight):
            animator.SetBool("MoveRight", true);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("Turn", false);
            break;

        case bool _ when isMovingLeft || (isMovingUp && !isRight) || (isMovingDown && !isRight):
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveRight", false);
            animator.SetBool("Turn", false);
            break;

        case bool _ when isNotMovingHorizontal && isRight:
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("Turn", false);
            break;

        case bool _ when isNotMovingHorizontal && !isRight:
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            animator.SetBool("Turn", true);
            break;

        case bool _ when isNotMovingVertical && isRight:
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("Turn", false);
            break;

        case bool _ when isNotMovingVertical && !isRight:
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            animator.SetBool("Turn", true);
            break;
    }
}

}
