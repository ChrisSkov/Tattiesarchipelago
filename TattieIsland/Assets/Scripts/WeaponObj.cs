using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponObj : ScriptableObject
{
    public GameObject wepPrefab;
    public int currentlyEquippedWeaponNumber;
    public bool isRanged;
    public bool hasAmmo;
    public int maxAmmo;
    public int currentAmmo;
    public float attackRange;
    public float attackDamage;
    public ParticleSystem particles;
    public AudioClip attackSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animOverrideControl;
}
