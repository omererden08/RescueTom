using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FishRight;
    [SerializeField]
    private GameObject[] FishLeft;
    [SerializeField]
    private Transform Player;
    private float randomTime;

    private void Start()
    {
        randomTime = Random.Range(0, 4f);
        InvokeRepeating("SpawnRight", 4f, randomTime);
        InvokeRepeating("SpawnLeft", 4f, randomTime);
    }

    private void Update()
    {
        transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    }

    


    Vector2 RightSpawnPos()
    {
        float x = transform.position.x + 10f;
        float y = transform.position.y - 2f;
        
    
        Vector2 RandomPos = new Vector2(x, y);
        return RandomPos;
    }
    Vector2 LeftSpawnPos()
    {
        float x = transform.position.x - 10f;
        float y = transform.position.y - 3.5f;


        Vector2 RandomPos = new Vector2(x, y);
        return RandomPos;
    }

    void SpawnRight()
    {
        int RandomIndex = Random.Range(0, FishRight.Length);

        Instantiate(FishRight[RandomIndex], RightSpawnPos(), Quaternion.identity);
    }
    void SpawnLeft()
    {
        int RandomIndex = Random.Range(0, FishLeft.Length);

        Instantiate(FishLeft[RandomIndex], LeftSpawnPos(), Quaternion.identity);
    }
}
