using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RangedWeapon", menuName = "Weapons/Ranged", order = 2)]
public class RangedScriptObj : WeaponAbstract
{
    GameObject clone;
    public float throwForce;
    public AudioClip throwSound;
    public override void OnPickUp(Transform pos)
    {

        clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.transform.SetParent(pos);
        clone.transform.rotation = Quaternion.Euler(0, 0, 00);
        stats.currentWeapon = this;
    }

    public override void DropWeapon(Transform pos)
    {
        stats.currentWeapon = null;

        var pickUpClone = Instantiate(pickUpItem.pickUpPrefab, pos.position, pos.rotation);
        pickUpClone.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(clone);
    }
    public override void TriggerAttack(Animator anim, string trigger)
    {
        if (stats.currentWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);
    }
    public override void LeftClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
    {
        Destroy(clone);
        GameObject clone2 = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone2.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
        clone2.GetComponent<Explode>().startExplosionTimer = true;
        stats.currentWeapon = null;
    }

    public override void Attack(Transform pos, float force, AudioSource source)
    {
        Destroy(clone);
        GameObject clone2 = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone2.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        clone2.GetComponent<Explode>().startExplosionTimer = true;
        source.PlayOneShot(throwSound);
    }

    public override void RightClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
    {
        throw new System.NotImplementedException();
    }
    public override void SheathWeapon(Transform pos)
    {
        clone.transform.SetParent(pos);
        clone.transform.position = pos.position;
    }

    public override void UnSheathWeapon(Transform pos)
    {
        clone.transform.SetParent(pos);
        clone.transform.position = pos.position;
    }
}
