using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RangedWepObj : RangedWeapon
{
    public float damage;
    public GameObject prefab;
    public Transform hand;
    public AnimatorOverrideController animOverride;
    public override void SpawnMeIn()
    {
        Instantiate(prefab, hand.transform.position,hand.transform.rotation);
    }

    public override void AnimEvent()
    {
        var clone = Instantiate(prefab, hand.position, hand.rotation);
        clone.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    }

}
