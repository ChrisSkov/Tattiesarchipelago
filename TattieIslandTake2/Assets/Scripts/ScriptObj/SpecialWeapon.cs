using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpecialWeapon : ScriptableObject
{
    public Player player;

    public GameObject pickUpObject;
    public GameObject weaponPrefab;
    public float damage;
    public float range;
    public float explodeForce;
    public float timeBetweenUses;
    public float pickUpDistance;
    public int weaponCount;
    public AnimatorOverrideController animOverride;

    public AudioClip throwSound;
    public AudioClip hitSound;

    public Sprite weaponIcon;
    public abstract void PickUp();
    public abstract void TriggerWeaponAnimation(Animator anim, string trigger);
    public abstract void SpecialWeaponAnimEvent(AudioSource source, Transform pos, float force);


}


