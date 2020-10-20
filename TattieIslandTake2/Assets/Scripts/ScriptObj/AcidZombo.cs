using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AcidZombo : BaseZombo
{
    public AudioClip[] acidSprayChargeUpSounds;
    public AudioClip[] acidSpraySounds;

    public GameObject acidSpray;
    public GameObject acidSprayCone;
    public override void Attack(Transform aim, AudioSource source)
    {
        Transform acidSprayAim = aim.transform.GetChild(5).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        GameObject acidClone = Instantiate(acidSpray, acidSprayAim.position, acidSprayAim.rotation);
        acidClone.transform.SetParent(acidSprayAim);
        GameObject acidCone = Instantiate(acidSprayCone, acidSprayAim.position, acidSprayAim.rotation);
        acidCone.transform.SetParent(acidSprayAim);

        source.PlayOneShot(acidSpraySounds[Random.Range(0, acidSpraySounds.Length)]);
        Destroy(acidClone, 1f);
        Destroy(acidCone, 1f);
    }

    public override void AttackStartup(AudioSource source)
    {
        source.volume = 0.8f;
        source.PlayOneShot(acidSprayChargeUpSounds[Random.Range(0, acidSprayChargeUpSounds.Length)]);
    }

}
