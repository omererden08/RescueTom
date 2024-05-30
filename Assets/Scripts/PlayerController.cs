using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    private Collider2D playerCollider2D;
    public GameObject[] PauseMenu;
    public GameObject Endimage;
    private Vector2 move;
    Quaternion targetRotation;
    private float horizontalInput;
    private float verticalInput;
    private bool isRight;
    public bool isPaused;
    public bool isGameOver;
    public GameObject Controls;
    public GameObject[] endGame;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;
    private AudioSource moveSound;
    public GameManager manager;
    public SceneTransition transition;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        playerCollider2D = GetComponent<Collider2D>();
        moveSound = GetComponent<AudioSource>();
        isRight = true;
        isPaused = false;
        isGameOver = false;
        speed = 0;
    }

    private void Update() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        CheckRotation();
        BackgroundSound();
        if (!isGameOver)
        {
            PauseGame();
        }
        else if (isGameOver)
        {
            transition.isEntered = false;
            transition.image.gameObject.SetActive(true);
            Cursor.visible = true;
        }
    }
    public void FixedUpdate()
    {
        if ((verticalInput != 0f || horizontalInput != 0f) && speed < maxSpeed)
        {
            speed += acceleration * Time.fixedDeltaTime;

            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (verticalInput == 0f && horizontalInput == 0f && speed > 0f)
        {
            speed -= deceleration * Time.fixedDeltaTime;
        }
        else if (speed < 0f)
        {
            speed = 0f;
        }
        if (!isGameOver)
        {          
            move = new Vector2(horizontalInput, verticalInput);

            playerRb.velocity = move * speed * Time.fixedDeltaTime;
            
            MoveAnimation();
            
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HealthManager.health -= 1;
            
            manager.collisionSound.Play();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            HealthManager.health -= 1;
            
            manager.collisionSound.Play();
        }
        else if (collision.gameObject.CompareTag("End"))
        {
            Endimage.SetActive(true);
            transition.isEntered = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
        {
            FuelManager.instance.IncreaseFuel();
            Destroy(other.gameObject);  
            manager.fuelSound.Play();
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
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            PauseMenu[0].SetActive(true);
            PauseMenu[1].SetActive(true);   
            Cursor.visible = true;
            Debug.Log("pause");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            PauseMenu[0].SetActive(false);
            PauseMenu[1].SetActive(false);           
            Cursor.visible = false;
            Debug.Log("resume");
        }
    }

    void CheckRotation()
    {
        if (!isRight)
        {
            targetRotation = Quaternion.Euler(playerCollider2D.transform.eulerAngles.x, 180, playerCollider2D.transform.eulerAngles.z);
        }
        if (isRight)
        {
            targetRotation = Quaternion.Euler(playerCollider2D.transform.eulerAngles.x, 0, playerCollider2D.transform.eulerAngles.z);
        }
        playerCollider2D.transform.rotation = targetRotation;
    }

    void BackgroundSound()
    {
        if (playerRb.velocity.x != 0 && !moveSound.isPlaying && !isPaused && !isGameOver || playerRb.velocity.y != 0 && !moveSound.isPlaying && !isPaused && !isGameOver)
        {
            moveSound.Play();
            Controls.gameObject.SetActive(false);
            print("5");
        }

        else if (playerRb.velocity.x != 0 && moveSound.isPlaying && !isPaused || playerRb.velocity.y != 0 && moveSound.isPlaying && !isPaused)
        {
            moveSound.loop = true;
        }
        
        else if (playerRb.velocity.x == 0 && moveSound.isPlaying || playerRb.velocity.y == 0 && moveSound.isPlaying)
        {
            moveSound.Stop();
            print("6");
        }
        if (isPaused || isGameOver)
        {
            moveSound.Stop();
        }
    }
}
