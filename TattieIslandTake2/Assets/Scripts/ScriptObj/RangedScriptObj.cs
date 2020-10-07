using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RangedScriptObj : WeaponAbstract
{
    GameObject clone;
    public float throwForce;
    public override void OnPickUp(Transform pos)
    {

        clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.transform.SetParent(pos);
        clone.transform.rotation = Quaternion.Euler(0,0,00);
       // clone.transform.rotation = Quaternion.Euler(90,0,0);
        stats.currentWeapon = this;
    }

    public override void DropWeapon(Transform pos)
    {
        stats.currentWeapon = null;

        var pickUpClone = Instantiate(pickUpItem.pickUpPrefab, pos.position, pos.rotation);
        pickUpClone.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(clone);
    }
    public override void triggerAttack(Animator anim, string trigger)
    {
        if (stats.currentWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);
    }
    public override void leftClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
    {
        Destroy(clone);
        GameObject clone2 = Instantiate(weaponPrefab, pos.position, pos.rotation);
        // clone.AddComponent<CapsuleCollider>();
        clone2.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
        clone2.GetComponent<Explode>().startExplosionTimer = true;
        stats.currentWeapon = null;
    }

    public override void attack(Transform pos, float force)
    {
        Destroy(clone);
        GameObject clone2 = Instantiate(weaponPrefab, pos.position, pos.rotation);
        // clone.AddComponent<CapsuleCollider>();
        clone2.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        clone2.GetComponent<Explode>().startExplosionTimer = true;
        stats.currentWeapon = null;
    }

    public override void rightClickAttack(Transform pos)
    {
        throw new System.NotImplementedException();
    }


}
