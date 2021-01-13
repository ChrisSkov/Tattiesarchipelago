﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class WeaponAbstract : ScriptableObject
{
    public GameObject weaponPrefab;
    public bool isThrowWeapon;
    public float leftClickDamage;
    public float rightClickDamage;
    public float timeBetweenAttacks;
    public bool isRightHanded;
    public float range;
    public float pickUpDistance;
    public float force;
    public bool pickUp = false;
    public bool hasAmmo = false;
    public AudioClip hitSound;
    public AnimatorOverrideController animOverride;
    public Player stats;
    public PickUpScriptObj pickUpItem;
    public Texture2D myIcon;
    public abstract void LeftClickAttack(Transform pos, Transform rayCastPosition, AudioSource source);
    public abstract void RightClickAttack(Transform pos, Transform rayCastPosition, AudioSource source);
    public abstract void TriggerAttack(Animator anim, string trigger);
    public abstract void OnPickUp(Transform pos);
    public abstract void DropWeapon(Transform pos);
    public abstract void UseSpecialWeapon(Transform pos, float throwForce, AudioSource source);
    public abstract void SheathWeapon(Transform pos);
    public abstract void UnSheathWeapon(Transform pos);

}
