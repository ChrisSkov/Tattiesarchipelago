using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Zombo : MonoBehaviour
{
    public EnemyStats zomboStats;
    public PlayerStats playerStats;
    public Transform handAim;
    EnemyHealth health;
    Animator anim;
    AIPath path;
    AudioSource source;

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
            attackTimer += Time.deltaTime;
            HandleMoveAnim();
            if (Vector3.Distance(transform.position, player.position) <= zomboStats.chaseRange)
            {
                path.destination = player.position;
                if (Vector3.Distance(transform.position, player.position) <= zomboStats.attackRange)
                {
                    if (attackTimer >= zomboStats.timeBetweenAttacks)
                    {
                        anim.SetTrigger("attack");
                        attackTimer = 0;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zomboStats.attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, zomboStats.chaseRange);
    }
}
