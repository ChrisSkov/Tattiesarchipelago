using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public PlayerStats stats;

    [SerializeField] GameObject[] weapons = new GameObject[3];
    Animator anim;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ShowCorrectWeapon(stats.currentlyEquippedWeapon);
        ThrowPunch();
    }


    public void ShowCorrectWeapon(int weaponID)
    {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].SetActive(i == weaponID);
    }
    private void ThrowPunch()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && stats.currentlyEquippedWeapon == 0)
        {
            anim.SetTrigger("attack");
        }
    }
    bool CriticalHit()
    {
        return Random.Range(0, 100) <= stats.critChance;
    }
    void PunchAnimEvent()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weapons[0].transform.position, stats.unarmedRange, mask))
        {
            if (CriticalHit())
            {
                print("CRIIIIT!");
                c.gameObject.GetComponent<EnemyHealth>().TakeDamage(stats.unarmedDamage * stats.critDamageMultiplier);
            }
            else
            {
                c.gameObject.GetComponent<EnemyHealth>().TakeDamage(stats.unarmedDamage);
            }
            source.PlayOneShot(stats.punchSound);

            if (Physics.Raycast(transform.position, c.transform.position - transform.position, out hit, mask))
            {
                c.GetComponent<Rigidbody>().AddForce(-hit.normal * stats.unarmedKnockbackForce, ForceMode.Impulse);
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(weapons[0].transform.position, stats.unarmedRange);

    }
}
