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
        if (anim.GetBool("canAttack"))
        {
            ShowCorrectWeapon(stats.currentlyEquippedWeapon);
            ThrowPunch();
            ThrowRightPunch();
        }
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
    private void ThrowRightPunch()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && stats.currentlyEquippedWeapon == 0)
        {
            anim.SetTrigger("rightClick");
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
                c.gameObject.GetComponent<EnemyHealth>().TakeDamage(stats.leftHandDamage * stats.critDamageMultiplier);
                var clone = Instantiate(stats.critEffect, weapons[0].transform.position, weapons[0].transform.rotation);
                Destroy(clone, 0.3f);
            }
            else
            {
                c.gameObject.GetComponent<EnemyHealth>().TakeDamage(stats.leftHandDamage);
            }

            source.PlayOneShot(stats.punchSound);

            if (Physics.Raycast(transform.position, c.transform.position - transform.position, out hit, mask))
            {
                c.GetComponent<Rigidbody>().AddForce(-hit.normal * stats.unarmedKnockbackForce, ForceMode.Impulse);
            }
        }
    }
    void RightPunchAnimEvent()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(weapons[2].transform.position, stats.unarmedRange, mask))
        {
            c.gameObject.GetComponent<EnemyHealth>().TakeDamage(stats.rightHandDamage);
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
