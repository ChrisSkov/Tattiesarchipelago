using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    [Header("Health Variables")]
    public float maxHp;
    public float currentHp;
    public float healthRegen;
    public float healthRegenTime;
    [Header("locomotion Variables")]
    public float moveSpeed;
    public float stepSoundDelay;
    public AudioClip walkSound;
    [Header("Weapon Variables")]
    public int currentlyEquippedWeapon;

    [Header("Unarmed Variables")]
    public float leftHandDamage;
    public float rightHandDamage;
    public float unarmedRange;
    public float unarmedKnockbackForce;
    public AudioClip punchSound;
    public AudioClip[] throwSounds;
    [Header("Misc variables")]
    public float constructionSpeed;
    public float potionMultiplier;
    public bool hasPickUpItem;
    [Header("Crit variables")]
    public float critChance;
    public float critDamageMultiplier;
    public GameObject critEffect;
    public AudioClip critSound;
    [Header("Energy variables")]
    public float maxEnergy;
    public float energyRegen;

}
