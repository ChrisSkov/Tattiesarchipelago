using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BaseMeleeWeapon", menuName = "Weapons/MeleeWeapon", order = 0)]
public class MeleeScriptObj : WeaponAbstract
{

    GameObject clone;
    public override void TriggerAttack(Animator anim, string trigger)
    {
        if (stats.currentWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);


    }
    public override void LeftClickAttack(Transform weaponPosition, Transform rayCastPosition, AudioSource source)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weaponPosition.position, range, mask))
        {
            if (Physics.Raycast(rayCastPosition.position, c.gameObject.transform.position - rayCastPosition.position, out hit, 100f, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * force, ForceMode.Impulse);
                if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(leftClickDamage + stats.stats.dmgModifier.statValue);
                }
                source.PlayOneShot(stats.currentWeapon.hitSound);

            }
        }
    }
    public override void RightClickAttack(Transform weaponPosition, Transform rayCastPosition, AudioSource source)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weaponPosition.position, range * 2, mask))
        {
            if (Physics.Raycast(rayCastPosition.position, c.gameObject.transform.position - rayCastPosition.position, out hit, 100f, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * force * 1.3f, ForceMode.Impulse);
                if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(rightClickDamage + stats.stats.dmgModifier.statValue);
                }
                source.PlayOneShot(stats.currentWeapon.hitSound);

            }
        }
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

    public override void UseSpecialWeapon(Transform pos, float throwForce, AudioSource source)
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
