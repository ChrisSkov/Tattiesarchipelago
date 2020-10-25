using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player", order = 0)]
public class Player : ScriptableObject
{
    public WeaponAbstract currentWeapon;
    public WeaponAbstract sheathedWeapon;
    public GameObject blood;
    public Transform activeHand;
    public PlayerStats stats;
    public PlayerResources resources;
    public bool closeToPickUp;
    public bool hasThrowable;
    public float stepSoundDelay;
    public bool canMove;
    public bool isDead;
    public bool canAttack;
    public int moneyCount;
    public AudioClip walkSound;
    public AudioClip deathSound;
    public AudioClip[] takeDamageSounds;
}

