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
    public float range;
    public bool pickUp = false;
    public AnimatorOverrideController leftClickOverride;
    public AnimatorOverrideController rightClickOverride;


    public override void triggerAttack(Animator anim, string trigger)
    {
        anim.runtimeAnimatorController = leftClickOverride;
        anim.SetTrigger(trigger);
    }
    public override void leftClickAttack(Transform pos)
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(pos.position, range, mask))
        {
            if (Physics.Raycast(Vector3.forward, Vector3.forward * 3, out hit, 100f, mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * 15, ForceMode.Impulse);
            }
        }
    }
    public override void rightClickAttack(Transform pos)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPickUp(Transform pos)
    {
        
        var clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.transform.SetParent(pos);
        clone.GetComponentInParent<Fight>().weapon = this;
    }


}
