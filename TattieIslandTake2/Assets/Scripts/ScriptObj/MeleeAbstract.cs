using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class MeleeAbstract : ScriptableObject
{
    public GameObject weaponPrefab;
    public float leftClickDamage;
    public float rightClickDamage;
    public float timeBetweenAttacks;
    public bool isRightHanded;
    public float range;
    public bool pickUp = false;
    public AnimatorOverrideController animOverride;
    public PlayerStats stats;
    public PickUpScriptObj pickUpItem;
    public abstract void leftClickAttack(Transform pos, Transform rayCastPosition);
    public abstract void rightClickAttack(Transform pos);
    public abstract void triggerAttack(Animator anim, string trigger);
    public abstract void OnPickUp(Transform pos);
    public abstract void DropWeapon(Transform pos);
}
