using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BaseZombo : ZomboAbstract
{
    public override void Attack(Transform handAim, AudioSource source)
    {
        LayerMask mask = LayerMask.GetMask("IgnoreWeapon");
        foreach (Collider c in Physics.OverlapSphere(handAim.position, attackRange, mask))
        {
            if (c.gameObject.tag == "Player")
            {
                source.volume = 0.3f;
                c.gameObject.GetComponent<Health>().TakeDamage(damage);
                source.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
            }
        }
    }

    public override void AttackStartup(AudioSource source)
    {
        throw new System.NotImplementedException();
    }
}
