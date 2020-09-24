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
    [Header("Weapon Variables")]
    public int currentlyEquippedWeapon;
    public AudioClip walkSound;

    [Header("Unarmed Variables")]
    public float unarmedDamage;
    public float unarmedRange;
    public float unarmedKnockbackForce;
    public AudioClip punchSound;
    [Header("Misc variables")]
    public float constructionSpeed;
    public float potionMultiplier;
    [Header("Crit variables")]
    public float critChance;
    public float critDamageMultiplier;
    [Header("Energy variables")]
    public float maxEnergy;
    public float energyRegen;

}
