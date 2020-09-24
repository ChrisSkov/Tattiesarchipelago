using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySavage : MonoBehaviour
{
    public EnemyStats stats;
    Animator anim;
    AIPath path;
    Transform player;
    [SerializeField] Transform spearAim = null;
    [SerializeField] float spearRadius = 2f;

    public float timer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        path = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerInChaseRange() && !anim.GetBool("lowHealth"))
        {
            path.destination = player.position;
        }
        if (stats.currentHp <= stats.fleeThreshold)
        {
            anim.SetBool("lowHealth", true);
            bool hasFleeDestination = false;
            if (!hasFleeDestination)
            {
                path.destination = transform.TransformDirection(Vector3.forward * 3);
            }
        }
        timer += Time.deltaTime;
        HandleMoveAnim();
        StabBehavior();
    }

    bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, player.position) <= stats.chaseRange;
    }
    bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) <= stats.attackRange;
    }
    private void StabBehavior()
    {
        if (PlayerInAttackRange() && !anim.GetBool("lowHealth"))
        {
            transform.LookAt(player.position);
            if (timer >= stats.timeBetweenAttacks)
            {
                anim.SetTrigger("attack");
            }
        }
    }

    void StabAnimEvent()
    {
        timer = 0f;
        foreach (Collider c in Physics.OverlapSphere(spearAim.position, spearRadius))
        {
            if (c.gameObject.tag == "Player")
            {
                c.gameObject.GetComponent<HealthScriptObj>().stats.currentHp -= stats.damage;
            }
        }
    }

    private void HandleMoveAnim()
    {
        if (path.velocity.magnitude > 0.5)
        {
            anim.SetBool("isMoving", true);
        }
        else if (path.velocity.magnitude <= 0.5)
        {
            anim.SetBool("isMoving", false);
        }
        float xVelocity = path.velocity.x;
        float yVelocity = path.velocity.z;
        anim.SetFloat("horizontalSpeed", xVelocity);
        anim.SetFloat("forwardSpeed", yVelocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(spearAim.position, spearRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.chaseRange);
    }

}
