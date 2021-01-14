using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnPoints;

    public GameObject[] rockPrefabs;

    public int maxAmountOfRocks;
    public int currentRockAmount;

    public float timeBetweenRockSpawn = 15f;
    public float timer = 0f;
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("RockSpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenRockSpawn)
        {
            StartRockSpawn();
            timer = 0f;
        }
    }

    private void StartRockSpawn()
    {
        if (currentRockAmount <= maxAmountOfRocks)
        {
            for (int i = 0; i <= maxAmountOfRocks; i++)
            {
                int rockPrefabIndex = Random.Range(0, rockPrefabs.Length);
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                if (spawnPoints[spawnPointIndex].transform.childCount == 0 && currentRockAmount < maxAmountOfRocks)
                {
                    Instantiate(rockPrefabs[rockPrefabIndex], spawnPoints[spawnPointIndex].transform);
                    currentRockAmount++;
                }

            }
        }
    }
}
