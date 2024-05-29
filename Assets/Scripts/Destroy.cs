using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject playerPos;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        DestroyPrefabs();
    }

    void DestroyPrefabs()
    {
        if(transform.position.y > playerPos.transform.position.y + 20)
        {
            Destroy(gameObject);
        }          
    }
}