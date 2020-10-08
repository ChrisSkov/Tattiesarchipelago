using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed;
    public float maxHp; 
    public float damage;
    public float destroyTime;
    public float walkSoundDelay;
    public AudioClip walkSound;

    
}
