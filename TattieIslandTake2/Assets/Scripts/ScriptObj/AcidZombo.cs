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
        //Transform acidSprayAim = aim.transform.GetChild(5).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        GameObject acidClone = Instantiate(acidSpray, aim.position, aim.rotation);
        acidClone.transform.SetParent(aim);
        GameObject acidCone = Instantiate(acidSprayCone, aim.position, aim.rotation);
        acidCone.transform.SetParent(aim);

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
