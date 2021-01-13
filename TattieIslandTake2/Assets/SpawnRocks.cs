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
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("RockSpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && currentRockAmount < maxAmountOfRocks)
        {
            for (int i = 0; i < maxAmountOfRocks; i++)
            {
                Instantiate(rockPrefabs[Random.Range(0, rockPrefabs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform);
                currentRockAmount++;
            }
        }
    }
}
