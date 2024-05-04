using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    public Image background;
    public Color color;
    IEnumerator enumerator;

    private void Start()
    {
        color = background.color;     
    }

    private void FixedUpdate()
    {
        enumerator = colorChange();
        StartCoroutine(enumerator);
    }

    IEnumerator colorChange()
    {
        yield return new WaitForFixedUpdate();
        
        if(TextWriter.Instance.endText == true)
        {
            color.a -= 0.5f * Time.fixedDeltaTime;
            background.color = color;
            Debug.Log("123");
        }
        else if(TextWriter.Instance.endText == false)
        {
            color.a += 0.5f * Time.fixedDeltaTime;
            background.color = color;
            Debug.Log("456");
        }
    }
    
}
