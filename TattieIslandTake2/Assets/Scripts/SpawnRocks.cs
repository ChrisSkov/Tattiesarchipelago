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
        if (Input.GetKeyDown(KeyCode.M) && currentRockAmount < maxAmountOfRocks)
        {
            for (int i = 0; i < maxAmountOfRocks; i++)
            {
                int rockPrefabIndex = Random.Range(0, rockPrefabs.Length);
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                if (spawnPoints[spawnPointIndex].transform.childCount == 0)
                {
                    Instantiate(rockPrefabs[rockPrefabIndex], spawnPoints[rockPrefabIndex].transform);
                    currentRockAmount++;
                }
                
            }
        }
    }
}
