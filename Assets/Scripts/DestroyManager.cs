using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void Update()
    {
        if(TextWriter.Instance.endText == true)
        {
            Destroy(gameObject);
        }
    }

}
