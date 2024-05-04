using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);   
    }
}
