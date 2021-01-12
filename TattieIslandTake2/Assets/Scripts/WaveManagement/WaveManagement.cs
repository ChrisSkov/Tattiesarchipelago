using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text text;
    public Player player;
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
                timeBetweenWaves = Random.Range(30, 220);
            }



            if (enemyTimer >= timeBetweenEnemies && enemiesSpawnedInCurrentWave < maxEnemiesInCurrentWave)
            {
                timeBetweenEnemies = Random.Range(3, 23);
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


}
