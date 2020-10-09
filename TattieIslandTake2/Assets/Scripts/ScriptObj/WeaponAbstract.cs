using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class WeaponAbstract : ScriptableObject
{
    public GameObject weaponPrefab;
    public bool isThrowWeapon;
    public float leftClickDamage;
    public float rightClickDamage;
    public float timeBetweenAttacks;
    public bool isRightHanded;
    public float range;
    public float force;
    public bool pickUp = false;
    public AudioClip hitSound;
    public AnimatorOverrideController animOverride;
    public PlayerStats stats;
    public PickUpScriptObj pickUpItem;
    public abstract void leftClickAttack(Transform pos, Transform rayCastPosition, AudioSource source);
    public abstract void rightClickAttack(Transform pos);
    public abstract void triggerAttack(Animator anim, string trigger);
    public abstract void OnPickUp(Transform pos);
    public abstract void DropWeapon(Transform pos);
    public abstract void attack(Transform pos, float throwForce, AudioSource source);
    public abstract void SheathWeapon(Transform pos);
    public abstract void UnSheathWeapon(Transform pos);
}
