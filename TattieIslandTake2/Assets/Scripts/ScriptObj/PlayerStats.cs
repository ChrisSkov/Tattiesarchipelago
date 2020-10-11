using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "TattieIslandTake2/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
    public WeaponAbstract currentWeapon;
    public WeaponAbstract sheathedWeapon;
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
}

