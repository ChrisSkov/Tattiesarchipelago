using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed;
    public float chaseRange;
    public float attackRange;
    public float damage;
    public float timeBetweenAttacks;
    public float maxHp;
    public float currentHp;
    public bool fleeOnLowHealth;
    public float fleeThreshold;
    public float destroyTime;
    public bool isDead = false;
}
