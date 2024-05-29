using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
  
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (CompareTag("FishLeft"))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (CompareTag("FishRight"))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        Destroy(gameObject, 5f);


    }
    
}
