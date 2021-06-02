using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManagement : MonoBehaviour
{
    public Player player;
    [Header("Wave Setup")]
    public WaveSet waveSet = null;
    public GameObject[] spawnPoints = null;
    [Header("Wave Timers")]
    public float timeBetweenWaves = 45f;
    public float timeBetweenWavesMin = 4f;
    public float timeBetweenWavesMax = 25f;
    [Header("Enemy Timers")]
    public float timeBetweenEnemies = 2f;
    public float timeBetweenEnemiesMin = 2f;
    public float timeBetweenEnemiesMax = 2f;
    [Header("For debugging")]
    public Text text;
    public int currentWave = -1;
    public bool isSpawning = false;
    public int maxEnemiesInCurrentWave;
    public int enemiesSpawnedInCurrentWave;
    public float waveTimer = Mathf.Infinity;
    public float enemyTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "" + Mathf.RoundToInt(waveTimer);
        if (!player.isDead)
        {
            HandleTimers();

            if (StartNewWave())
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
                timeBetweenWaves = Random.Range(timeBetweenWavesMin, timeBetweenWavesMax);
            }



            if (TimeToSpawnEnemy() && NotAllEnemiesInWaveHaveSpawned())
            {
                timeBetweenEnemies = Random.Range(timeBetweenEnemiesMin, timeBetweenEnemiesMax);
                SpawnRandomEnemyFromWave();
                enemyTimer = 0f;
                enemiesSpawnedInCurrentWave++;
            }

            if (enemiesSpawnedInCurrentWave == maxEnemiesInCurrentWave)
            {
                isSpawning = false;

            }
        }


    }

    private void HandleTimers()
    {
        if (isSpawning)
        {
            enemyTimer += Time.deltaTime;
        }
        else
        {
            waveTimer += Time.deltaTime;
        }
    }

    private void SpawnRandomEnemyFromWave()
    {
        Instantiate(waveSet.waves[currentWave].enemyTypesInWave[Random.Range(0, waveSet.waves[currentWave].enemyTypesInWave.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.rotation);
    }

    private bool StartNewWave()
    {
        return waveTimer >= timeBetweenWaves;
    }

    private bool NotAllEnemiesInWaveHaveSpawned()
    {
        return enemiesSpawnedInCurrentWave < maxEnemiesInCurrentWave;
    }

    private bool TimeToSpawnEnemy()
    {
        return enemyTimer >= timeBetweenEnemies;
    }
}
