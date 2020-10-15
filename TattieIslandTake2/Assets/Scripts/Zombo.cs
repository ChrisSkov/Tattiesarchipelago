﻿using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Zombo : MonoBehaviour
{
    public EnemyStats zomboStats;
    public PlayerStats playerStats;
    public Transform handAim;
    public Transform acidSprayAim;
    public GameObject acidSpray;
    public GameObject acidSprayCone;
    EnemyHealth health;
    Animator anim;
    AIPath path;
    AudioSource source;

    float specialAttackTimer = 0f;
    float attackTimer = Mathf.Infinity;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        path.maxSpeed = zomboStats.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.isDead)
        {
            if (playerStats.currentHealth <= 0)
            {
                path.isStopped = true;
                transform.LookAt(Camera.main.transform.GetChild(0).transform.position);
                anim.SetTrigger("victory");
            }
            else
            {
                specialAttackTimer += Time.deltaTime;
                attackTimer += Time.deltaTime;
                HandleMoveAnim();
                if (Vector3.Distance(transform.position, player.position) <= zomboStats.chaseRange)
                {
                    transform.LookAt(player.position);
                    path.destination = player.position;
                    if (Vector3.Distance(transform.position, player.position) <= zomboStats.attackRange)
                    {
                        if (specialAttackTimer >= zomboStats.timeBetweenSpecialAttack)
                        {
                            anim.SetTrigger("acidSpray");
                            specialAttackTimer = 0f;
                        }
                        if (attackTimer >= zomboStats.timeBetweenAttacks)
                        {
                            anim.SetTrigger("attack");
                            attackTimer = 0f;
                        }

                    }
                }
            }

        }
    }
    private void HandleMoveAnim()
    {
        if (path.velocity.magnitude >= 0.5)
        {
            anim.SetBool("isMoving", true);

        }
        else if (path.velocity.magnitude < 0.5)
        {
            anim.SetBool("isMoving", false);
        }
        float yVelocity = path.velocity.z;
        anim.SetFloat("forwardSpeed", yVelocity);
    }


    void TwoHandedSlamAttack()
    {

        LayerMask mask = LayerMask.GetMask("IgnoreWeapon");
        foreach (Collider c in Physics.OverlapSphere(handAim.position, zomboStats.attackRange, mask))
        {
            if (c.gameObject.tag == "Player")
            {

                c.gameObject.GetComponent<Health>().TakeDamage(zomboStats.damage);
                source.PlayOneShot(zomboStats.hitSound);
            }
        }
    }

    void AcidSprayAnimEvent()
    {
        GameObject acidClone = Instantiate(acidSpray, acidSprayAim.position, acidSprayAim.rotation);
        GameObject acidCone = Instantiate(acidSprayCone, acidSprayAim.position, acidSprayAim.rotation);
        Destroy(acidClone, 1f);
        Destroy(acidCone, 1f);
    }

    void CanMove()
    {
        path.canMove = true;
    }

    void CannotMove()
    {
        path.canMove = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zomboStats.attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, zomboStats.chaseRange);
    }
}
