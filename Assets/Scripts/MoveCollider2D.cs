using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider2D : MonoBehaviour
{
    private new Collider2D collider2D;
    public Transform target; 
    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if(collider2D.transform.position.y > target.transform.position.y + 6)
        {
            collider2D.transform.position = new Vector2(0, target.transform.position.y + 6);  
        }
    }
}
