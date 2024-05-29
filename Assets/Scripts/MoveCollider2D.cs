using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider2D : MonoBehaviour
{
    public  Collider2D upCollider2D;
    public Transform target;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if(upCollider2D.transform.position.y > target.transform.position.y + 6)
        {
            upCollider2D.transform.position = new Vector2(0, target.transform.position.y + 6);  
        }
    }
}
