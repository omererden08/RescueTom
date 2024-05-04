using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    IEnumerator loadlevel;
    public float transitionTime;
    public void StartGame()
    {
        SceneTransition.instance.isEntered = false;
        SceneTransition.instance.StartScreenTransition();
        loadlevel = LoadLevel(1);
        StartCoroutine(loadlevel);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
