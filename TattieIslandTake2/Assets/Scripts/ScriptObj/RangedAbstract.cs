using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RangedAbstract : ScriptableObject
{
    public PlayerStats stats;
    public GameObject weaponPrefab;
    public float leftClickDamage;
    public float rightClickDamage;
    public bool pickUp = false;
    public float range;
    public float timeBetweenAttacks;
    public float maxAmmo;
    public float currentAmmo;
    public bool isRightHanded;
    public AudioClip hitSound;
    public AnimatorOverrideController animOverride;
    public PickUpScriptObj pickUpItem;

}
