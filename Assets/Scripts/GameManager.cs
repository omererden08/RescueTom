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
    public bool menu;
    public bool restart;
    public GameObject image;
    public AudioSource collisionSound;
    public AudioSource backgroundSound;
    public AudioSource fuelSound;
    public AudioSource buttonSound;
    public SceneTransition transition;

    private void Start()
    {
        Invoke("Destroy", 1f);
    }

    public void StartGame()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        image.gameObject.SetActive(true);
        transition.isEntered = false;
    }
    public void QuitGame()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        image.gameObject.SetActive(true);
        transition.isEntered = false;
        Invoke("Application.Quit", 1f);

    }

    public void RestartGame()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        transition.isEntered = false;
        image.gameObject.SetActive(true);
        restart = true;
    }

    public void ReturnMenu()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        menu = true;
        image.gameObject.SetActive(true);
        transition.isEntered = false;
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
