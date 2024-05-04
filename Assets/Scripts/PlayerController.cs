using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 move;
    public float speed;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.velocity = move * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Obstacle")
        {
            HealthManager.health -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
        {
            FuelManager.instance.IncreaseFuel();
          
        }
        else if (other.CompareTag("Life"))
        {
            HealthManager.health += 1;
        }
    }
}
