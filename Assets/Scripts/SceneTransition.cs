using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Color color;
    public Image image;
    private IEnumerator screentransition;
    public bool isEntered;
    [SerializeField]
    private float transitionTime;
    public GameManager manager;
    public PlayerController player;
    

    
    private void Start()
    {
        color = image.color;
        isEntered = true;
        Time.timeScale = 1f;
        StartColorChange();
    }
    public void StartColorChange()
    {
        screentransition = ColorChange();
        StartCoroutine(screentransition);
    }
    public void StartSceneLoad()
    {
        if (manager.menu)
        {
            StartCoroutine(SceneLoad(0));
        }
        else if (manager.restart)
        {
            StartCoroutine(SceneLoad(2));
        }
        else if (player.isGameOver)
        {
            StartCoroutine(SceneLoad(5));
        }
        else
        {
            StartCoroutine(SceneLoad(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
    private void Update()
    {
        StartColorChange();
        if(!isEntered)
        {
            StartSceneLoad();
        }
    }
    IEnumerator ColorChange()
    {  
            yield return null;
            if (isEntered && color.a > 0)
            {
                color.a -= 1f * Time.deltaTime;
                image.color = color;               
            }
            else if (!isEntered)
            {
                color.a += 1f * Time.deltaTime;   
                image.color = color;         
            }                 
    }
    IEnumerator SceneLoad(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
