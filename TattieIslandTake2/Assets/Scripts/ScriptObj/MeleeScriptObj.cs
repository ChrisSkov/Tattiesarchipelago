using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MeleeScriptObj : MeleeAbstract
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
    GameObject clone;
    public override void triggerAttack(Animator anim, string trigger)
    {
        if (stats.currentWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);


    }
    public override void leftClickAttack(Transform weaponPosition, Transform rayCastPosition)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weaponPosition.position, range, mask))
        {
            if (Physics.Raycast(rayCastPosition.TransformDirection(Vector3.forward), c.gameObject.transform.position * 3, out hit, 100f, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * 4, ForceMode.Impulse);
            }
        }
    }
    public override void rightClickAttack(Transform pos)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPickUp(Transform pos)
    {
        clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.transform.SetParent(pos);
        stats.currentWeapon = this;
    }

    public override void DropWeapon(Transform pos)
    {
        stats.currentWeapon = null;

        var pickUpClone = Instantiate(pickUpItem.pickUpPrefab, pos.position, pos.rotation);
        pickUpClone.transform.rotation = Quaternion.Euler(90,0,0);
        Destroy(clone);
    }


}
