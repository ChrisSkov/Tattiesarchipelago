using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
    public WeaponAbstract currentWeapon;
    public WeaponAbstract sheathedWeapon;
    public GameObject blood;
    public Transform activeHand;
    public bool closeToPickUp;
    public bool hasThrowable;
    public float maxMoveSpeed;
    public float stepSoundDelay;
    public float currentMoveSpeed;
    public float maxHealth;
    public float currentHealth;
    public bool isDead;
    public bool canMove;
    public bool canAttack;
    public AudioClip walkSound;
    public AudioClip deathSound;
    public AudioClip[] takeDamageSounds;
}

