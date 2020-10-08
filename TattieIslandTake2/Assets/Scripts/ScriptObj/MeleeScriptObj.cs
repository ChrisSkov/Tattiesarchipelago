using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MeleeScriptObj : WeaponAbstract
{

    GameObject clone;
    public override void triggerAttack(Animator anim, string trigger)
    {
        if (stats.currentWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);


    }
    public override void leftClickAttack(Transform weaponPosition, Transform rayCastPosition, AudioSource source)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weaponPosition.position, range, mask))
        {
            if (Physics.Raycast(rayCastPosition.position, c.gameObject.transform.position - rayCastPosition.position, out hit, 100f, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * 8, ForceMode.Impulse);
                if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(leftClickDamage);
                }
                source.PlayOneShot(stats.currentWeapon.hitSound);

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
        pickUpClone.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(clone);
    }

    public override void attack(Transform pos, float throwForce)
    {
        throw new System.NotImplementedException();
    }
}
