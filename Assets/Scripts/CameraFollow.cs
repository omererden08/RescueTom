using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;

    private void LateUpdate()
    {
        if(target.transform.position.y >= 4)
        {
            transform.position = new Vector3(0, 4, -10);
        }
        else
        {
            transform.position = new Vector3(0, target.position.y, -10);
        }
    }
}
