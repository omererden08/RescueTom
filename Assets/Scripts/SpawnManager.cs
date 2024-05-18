using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fuelPrefab;
    [SerializeField]
    private GameObject[] ObstaclePrefabs;
    [SerializeField]
    private GameObject WallPrefabs;
    public Transform Player;
    [SerializeField]
    private float distanceBetweenFuelSpawnPoints;
    [SerializeField]
    private float distanceBetweenObstacleSpawnPoints;
    private float nextFuelSpawnPoint = 2f;
    private float nextObstacleSpawnPoint = 0f;
    private float nextWallSpawnPoint = 0f;




    private void Update()
    {
        SpawnFuel();
        WallSpawn();
        SpawnObstacle();
     
    }

    Vector2 RandomFuelPos()
    {
        float x = Random.Range(-5, 5);
        float y = Player.transform.position.y - 8;
        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    } 

    Vector2 RandomObstaclePos()
    {
        float x = 0f;
        float y = Player.transform.position.y - 8;
        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }

    Vector2 WallSpawnPos()
    {
        float x = 0;
        float y = Player.transform.position.y - 10f;
        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }

    void SpawnFuel()
    {
        if (Vector2.Distance(transform.position, Player.position) >= nextFuelSpawnPoint)
        {
            Instantiate(fuelPrefab, RandomFuelPos(), Quaternion.identity);
            nextFuelSpawnPoint += distanceBetweenFuelSpawnPoints;
        }
    }
    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, ObstaclePrefabs.Length);

        if (Vector2.Distance(transform.position, Player.position) >= nextObstacleSpawnPoint)
        {
            Instantiate(ObstaclePrefabs[randomIndex], RandomObstaclePos(), Quaternion.identity);
            nextObstacleSpawnPoint += distanceBetweenObstacleSpawnPoints;
        }

    }
    void WallSpawn()
    {
        if(Vector2.Distance(transform.position, Player.position) >= nextWallSpawnPoint)
        {
            Instantiate(WallPrefabs, WallSpawnPos(), Quaternion.identity);
            nextWallSpawnPoint += 10f;
        }
    }
}
