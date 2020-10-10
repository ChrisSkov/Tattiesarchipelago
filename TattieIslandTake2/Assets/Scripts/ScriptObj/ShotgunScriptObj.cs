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
    public override void Attack(Transform pos, float throwForce, AudioSource source)
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
        GameObject coneClone = Instantiate(coneCollider, pos.position, pos.rotation);
        GameObject particleClone = Instantiate(particles, pos.GetChild(0).transform.GetChild(0).transform.position, pos.rotation);
        particleClone.transform.Rotate(-90, -90, 0, Space.Self);
        source.PlayOneShot(shootSound);
    }


    public override void RightClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(pos.GetChild(0).transform.GetChild(1).transform.position, range, mask))
        {
            if (Physics.Raycast(rayCastPosition.position, c.gameObject.transform.position - rayCastPosition.position, out hit, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * 8, ForceMode.Impulse);
                if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(rightClickDamage);
                }
                source.PlayOneShot(stats.currentWeapon.hitSound);

            }
        }
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
