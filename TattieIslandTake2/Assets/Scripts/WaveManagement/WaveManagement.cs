using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    public WaveSet waveSet = null;
    public float timeBetweenWaves = 45f;
    public float timeBetweenEnemies = 2f;
    public bool isSpawning = false;
    public int currentWave = 0;
    public GameObject[] spawnPoints = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
