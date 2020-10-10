using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Zombo : MonoBehaviour
{
    public EnemyStats stats;
    EnemyHealth health;
    Animator anim;
    AIPath path;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        path.maxSpeed = stats.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoveAnim();
        if (!health.isDead)
        {
            if (Vector3.Distance(transform.position, player.position) <= stats.chaseRange)
            {
                path.destination = player.position;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.chaseRange);
    }
}
