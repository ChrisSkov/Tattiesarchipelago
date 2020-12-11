using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "SpecialWeapon", menuName = "SpecialWeapon", order = 0)]

public class DynamiteScriptObj : SpecialWeapon

{
    public override void PickUp()
    {
        weaponCount++;
    }

    public override void SpecialWeaponAnimEvent(AudioSource source, Transform pos, float force)
    {
        GameObject clone = Instantiate(weaponPrefab, pos.position, pos.rotation);
        clone.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        clone.GetComponent<Explode>().startExplosionTimer = true;
        source.PlayOneShot(throwSound);
        player.dynamitesThrown.statValue++;
        weaponCount--;
    }

    public override void TriggerWeaponAnimation(Animator anim, string trigger)
    {
        if (player.selectedSpecialWeapon.animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        anim.SetTrigger(trigger);
    }
}
