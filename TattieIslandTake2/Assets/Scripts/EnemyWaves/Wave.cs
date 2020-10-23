using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Wave", menuName = "Waves/Wave", order = 1)]
public class Wave : ScriptableObject
{
    public GameObject[] enemyTypesInWave;
    public int[] numberOfEnemies;
}
