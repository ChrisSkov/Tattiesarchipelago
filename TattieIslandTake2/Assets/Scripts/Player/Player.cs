using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player", order = 0)]
public class Player : ScriptableObject
{
    [Header("Scriptable Objects")]
    public PlayerStats stats;
    public PlayerResources resources;
    public PlayerAudio playerAudio;
    public LevelUpProgression progression;
    [Header("Weapon stuff")]
    public WeaponAbstract currentWeapon;
    public WeaponAbstract sheathedWeapon;
    public Transform activeHand;
    [Header("Player States")]
    public bool canAttack;
    public bool canMove;
    public bool closeToPickUp;
    public bool hasThrowable;
    public bool isSlowed;
    public bool isDead;
    [Header("DeathScreenStats")]
    public StatScriptObj zombiesKilled;
    public StatScriptObj dynamitesThrown;
    [Header("Misc")]
    public GameObject blood;
    public float stepSoundDelay;
    public ConsumableAbstract activeConsumable;

    public Vector3 mouseWorldPosition;

    public BuildingScriptObj currentlySelectedBuilding;
    public bool previewBuilding;

    public Animator anim;
}

