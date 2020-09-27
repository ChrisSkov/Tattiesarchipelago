using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySavage : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField] Transform spearAim = null;
    [SerializeField] float spearRadius = 2f;
    [SerializeField] AudioClip stabSound = null;
    public bool isFleeing = false;
    public float timer = Mathf.Infinity;
    EnemyHealth health;
    Animator anim;
    AIPath path;
    Transform player;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        health = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        path = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            path.maxSpeed = 0f;
            return;
        }
        else
        {
            timer += Time.deltaTime;
            HandleMoveAnim();
            if (LowHealth())
            {
                FleeBehavior();
            }
            else
            {
                ChaseBehavior();
                StabBehavior();
            }
        }
    }

    private void ChaseBehavior()
    {
        if (!anim.GetBool("lowHealth"))
        {
            if (PlayerInChaseRange())
            {
                path.destination = player.position;
            }
        }
    }

    private void FleeBehavior()
    {

        if (LowHealth())
        {
            if (!isFleeing)
            {
                path.maxSpeed = stats.fleeSpeed;
                path.destination = transform.TransformDirection(Vector3.back * 100);
                isFleeing = true;
            }
        }
    }
    private void StabBehavior()
    {
        if (PlayerInAttackRange() && !LowHealth())
        {
            transform.LookAt(player.position);
            path.maxSpeed = 0f;
            if (timer >= stats.timeBetweenAttacks)
            {
                timer = 0f;
                anim.SetTrigger("attack");
            }
        }
        else
        {
            path.maxSpeed = stats.moveSpeed;
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

    void StabAnimEvent()
    {
        foreach (Collider c in Physics.OverlapSphere(spearAim.position, spearRadius))
        {
            if (c.gameObject.tag == "Player")
            {
                c.gameObject.GetComponent<HealthScriptObj>().stats.currentHp -= stats.damage;
                source.PlayOneShot(stabSound);
            }
        }
    }

    bool LowHealth()
    {
        if (health.currentHp <= stats.fleeThreshold)
        {
            anim.SetBool("lowHealth", true);
            return true;
        }
        else
        {
            return false;
        }
    }

    bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, player.position) <= stats.chaseRange;
    }
    bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) <= stats.attackRange;
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
