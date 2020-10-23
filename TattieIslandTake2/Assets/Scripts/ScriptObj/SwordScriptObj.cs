using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Sword/Shovel/Bat/etc", menuName = "Weapons/Sword", order = 1)]
public class SwordScriptObj : WeaponAbstract
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
    public override void LeftClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(pos.GetChild(0).transform.GetChild(0).transform.position, range, mask))
        {
            Debug.Log(c.name);
            if (c.gameObject.name != "Floor")
            {
                if (c.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    c.gameObject.GetComponent<EnemyHealth>().TakeDamage(leftClickDamage);
                }

                if (Physics.Raycast(rayCastPosition.position, c.gameObject.transform.position - rayCastPosition.position, out hit, mask))
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * 8, ForceMode.Impulse);
                }
                source.PlayOneShot(stats.currentWeapon.hitSound);
            }
        }
    }

    public override void RightClickAttack(Transform pos, Transform rayCastPosition, AudioSource source)
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
        Destroy(clone);
    }

    public override void Attack(Transform pos, float throwForce, AudioSource source)
    {
        throw new System.NotImplementedException();
    }

    public override void SheathWeapon(Transform pos)
    {
        clone.transform.SetParent(pos);
        clone.transform.position = pos.position;
        clone.transform.rotation = pos.rotation;

    }

    public override void UnSheathWeapon(Transform pos)
    {
        clone.transform.SetParent(pos);
        clone.transform.position = pos.position;
        clone.transform.rotation = pos.rotation;
    }
}
