using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class TextWriter : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float startDelay;
    private float textSpeed = 0.07f;
    private int index;
    public bool endText;

    public static TextWriter Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {           
        textComponent.text = string.Empty;
        endText = false;
        Invoke("StartDialogue", startDelay);
    }
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());       
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneTransition.instance.isEntered = false;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                SceneTransition.instance.StartColorChange();
            }
        }
    }
}
