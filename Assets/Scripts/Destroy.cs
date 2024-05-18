using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Update()
    {
        if (CompareTag("Obstacle"))
        {
            Destroy(gameObject, 30f);
        }
        else
        {
            Destroy(gameObject, 7f);
        }
    }
}
