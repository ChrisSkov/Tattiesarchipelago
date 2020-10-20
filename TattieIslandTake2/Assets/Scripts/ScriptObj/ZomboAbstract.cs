using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZomboAbstract : ScriptableObject
{
    [Header("locomotion")]
    public float moveSpeed;
    public float chaseRange;
    public float walkSoundDelay;
    public AudioClip walkSound;
    [Header("Combat")]
    public float attackRange;
    public float timeBetweenAttacks;
    public float damage;
    public AudioClip[] attackSounds;
    [Header("Life and Death")]
    public float maxHp;
    public float destroyTime;
    public GameObject[] organs;
    public AudioClip[] takeDamageSounds;
    [Header("Misc")]
    public AudioClip[] idleSounds;
    public AnimatorOverrideController animOverride;

    public abstract void Attack(Transform aim, AudioSource source);
    public abstract void AttackStartup(AudioSource source);

}
