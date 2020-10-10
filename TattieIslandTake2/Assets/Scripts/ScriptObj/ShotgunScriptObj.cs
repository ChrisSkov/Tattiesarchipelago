using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ShotgunScriptObj : WeaponAbstract
{
    GameObject clone;
    public GameObject particles;
    public GameObject coneCollider;
    public AudioClip shootSound;
    public override void attack(Transform pos, float throwForce, AudioSource source)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPickUp(Transform pos)
    {

        clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.transform.SetParent(pos);
        clone.transform.rotation = pos.rotation;
        clone.transform.Rotate(new Vector3(0, 180, -90), Space.Self);
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
        GameObject coneClone = Instantiate(coneCollider, pos.position, pos.rotation);
        GameObject particleClone = Instantiate(particles, pos.GetChild(0).transform.GetChild(0).transform.position, pos.rotation);
        particleClone.transform.Rotate(-90, -90, 0, Space.Self);
        source.PlayOneShot(shootSound);
    }


    public override void rightClickAttack(Transform pos)
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
        clone.transform.rotation = pos.rotation;
        clone.transform.Rotate(new Vector3(0, 180, -90), Space.Self);
    }

}
