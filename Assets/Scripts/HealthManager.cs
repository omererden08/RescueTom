using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    public static int health;
    public PlayerController playerController;
    private void Start()
    {
        health = hearts.Length;
        hearts[0].gameObject.SetActive(true);
        hearts[1].gameObject.SetActive(true);
        hearts[2].gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    public void Update()
    {
        
        if(health > 3)
        {
            health = 3;
        }
        else if (health < 0)
        {
            health = 0;
        }

        switch (health)
        {
            case 3:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                break;
            case 2:
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                break;
            case 1:
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(true);
                break;
            case 0:
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                playerController.isGameOver = true;                
                break;
        }
    }
}
