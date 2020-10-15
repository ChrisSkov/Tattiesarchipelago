using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed;
    public float maxHp; 
    public float chaseRange; 
    public float attackRange; 
    public float timeBetweenAttacks; 
    public float timeBetweenSpecialAttack; 
    public float specialAttackdamage;
    public float damage;
    public float destroyTime;
    public float walkSoundDelay;
    public AudioClip walkSound;
    public AudioClip hitSound;
    public AudioClip[] attackSounds;

    
}
