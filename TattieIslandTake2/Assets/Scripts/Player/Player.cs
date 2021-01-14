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
    public TaskAbstract currentTaskObj;
    public BuildingScriptObj currentlySelectedBuilding;
    public ConsumableAbstract activeConsumable;
    [Header("Weapon stuff")]
    public Transform activeHand;
    public WeaponAbstract currentWeapon;
    public WeaponAbstract sheathedWeapon;
    public SpecialWeapon selectedSpecialWeapon;
    [Header("Player States")]
    public bool canAttack;
    public bool canMove;
    public bool closeToPickUp;
    public bool hasThrowable;
    public bool isSlowed;
    public bool isDead;
    public bool previewBuilding;
    public bool carryChicken;
    [Header("DeathScreenStats")]
    public StatScriptObj zombiesKilled;
    public StatScriptObj dynamitesThrown;
    [Header("Misc")]
    public float stepSoundDelay;
    public GameObject blood;
    public Animator anim;
    public Vector3 mouseWorldPosition;

}

