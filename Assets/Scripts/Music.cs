using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music;


    private void Awake()
    {
        DontDestroyOnLoad(music);
        if(Time.timeScale == 0)
        {
            music.Pause();
            Cursor.visible = true;
        }
        else
        {
            music.Play();
        }
    }

    

}
