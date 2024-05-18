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
    public bool isExited;
    [SerializeField]
    private float transitionTime;
    public static SceneTransition instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        color = image.color;
        isEntered = true;
        StartColorChange();
    }
    public void StartColorChange()
    {
        screentransition = ColorChange();
        StartCoroutine(screentransition);
        Debug.Log("özkan");
    }
    public void StartSceneLoad()
    {
        StartCoroutine(SceneLoad(SceneManager.GetActiveScene().buildIndex + 1));
    }
    private void FixedUpdate()
    {
        if(!isEntered && image.color.a == 255f)
        {
            Invoke("StartSceneLoad", 0.5f);
        }

    }
    IEnumerator ColorChange()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (isEntered == true)
            {
                color.a -= 0.7f * Time.fixedDeltaTime;
                image.color = color;               
            }
            else if (isEntered == false)
            {
                color.a += 0.7f * Time.fixedDeltaTime;
                image.color = color;              
            }
        }
    }
    IEnumerator SceneLoad(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
