using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Zombo : MonoBehaviour
{
    public ZomboAbstract zomboStats;
    public Player player;
    public Transform aim;
    EnemyHealth health;
    Animator anim;
    AIPath path;
    AudioSource source;
    public bool canRotate = true;
    float attackTimer = Mathf.Infinity;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
            if (player.stats.currentHealth <= 0)
            {
                path.isStopped = true;
                transform.LookAt(Camera.main.transform.GetChild(0).transform.position);
                anim.SetTrigger("victory");
            }
            else
            {
                // specialAttackTimer += Time.deltaTime;
                attackTimer += Time.deltaTime;
                HandleMoveAnim();
                if (Vector3.Distance(transform.position, playerTransform.position) <= zomboStats.chaseRange)
                {
                    if (canRotate)
                    {
                        transform.LookAt(playerTransform.position);
                    }
                    path.destination = playerTransform.position;
                    if (Vector3.Distance(transform.position, playerTransform.position) <= zomboStats.attackRange)
                    {
                        if (attackTimer >= zomboStats.timeBetweenAttacks)
                        {
                            if (zomboStats.animOverride != null)
                            {
                                anim.runtimeAnimatorController = zomboStats.animOverride;
                            }
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
        float yVelocity = Mathf.Abs(path.velocity.z);
        anim.SetFloat("forwardSpeed", yVelocity);
    }


    void ZomboChargeAttackAnimEvent()
    {
        zomboStats.AttackStartup(source);
    }
    void ZomboAttackAnimEvent()
    {
        zomboStats.Attack(aim, source);
    }
    void CanMove()
    {
        canRotate = true;
        path.canMove = true;
    }

    void CannotMove()
    {
        canRotate = false;
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
