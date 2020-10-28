using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    public WaveSet waveSet = null;
    public float timeBetweenWaves = 45f;
    public float timeBetweenEnemies = 2f;
    public bool isSpawning = false;
    public int currentWave = -1;
    public int maxEnemiesInCurrentWave;
    public int enemiesSpawnedInCurrentWave;
    public GameObject[] spawnPoints = null;
    public float enemyTimer = Mathf.Infinity;
    public float waveTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            enemyTimer += Time.deltaTime;
        }
        else
        {
            waveTimer += Time.deltaTime;
        }

        if (waveTimer >= timeBetweenWaves)
        {
            isSpawning = true;
            waveTimer = 0f;
            currentWave += 1;
            maxEnemiesInCurrentWave = 0;
            enemiesSpawnedInCurrentWave = 0;
            for (int i = 0; i < waveSet.waves[currentWave].numberOfEnemies.Length; i++)
            {
                maxEnemiesInCurrentWave += waveSet.waves[currentWave].numberOfEnemies[i];
            }
        }



        if (enemyTimer >= timeBetweenEnemies && enemiesSpawnedInCurrentWave < maxEnemiesInCurrentWave)
        {
            Instantiate(waveSet.waves[currentWave].enemyTypesInWave[Random.Range(0, waveSet.waves[currentWave].enemyTypesInWave.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.rotation);
            enemyTimer = 0f;
            enemiesSpawnedInCurrentWave++;
        }

        if (enemiesSpawnedInCurrentWave == maxEnemiesInCurrentWave)
        {
            isSpawning = false;

        }


    }


}
