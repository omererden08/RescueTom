using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    IEnumerator loadlevel;
    public float transitionTime;  
    public GameObject image;
    

    private void Start()
    {
        Invoke("Destroy", 1f);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        image.gameObject.SetActive(true);
        SceneTransition.instance.isEntered = false;
        SceneTransition.instance.StartColorChange();
        loadlevel = LoadLevel(1);
        StartCoroutine(loadlevel);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        image.gameObject.SetActive(true);
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        image.gameObject.SetActive(true);
        SceneTransition.instance.isEntered = false;
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Debug.Log("menu");
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    private void Destroy()
    {
        image.SetActive(false);
    }
}
