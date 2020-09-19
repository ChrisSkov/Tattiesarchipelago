using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySavage : MonoBehaviour
{

    Animator anim;
    AIPath path;
    Transform player;
    [SerializeField] Transform spearAim = null;
    [SerializeField] float spearRadius = 2f;
    [SerializeField] float spearDamage = 10f;
    [SerializeField] float stabRange = 10f;
    [SerializeField] float timeBetweenAttacks = 1.5f;
    EnemyHealth health;
    [SerializeField] float fleeThreshold = 30f;
    public float timer = Mathf.Infinity;
    bool isFleeing = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = GetComponent<EnemyHealth>();
        path = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.GetCurrentHP() <= fleeThreshold)
        {
            anim.SetBool("lowHealth", true);
            bool hasFleeDestination = false;
            if(!hasFleeDestination)
            {
                path.destination = transform.TransformDirection(Vector3.forward * 3);
            }
        }
        timer += Time.deltaTime;
        HandleMoveAnim();
        StabBehavior();
    }

    private void StabBehavior()
    {
        if (Vector3.Distance(transform.position, player.position) <= stabRange && !anim.GetBool("lowHealth"))
        {
            transform.LookAt(player.position);
            if (timer >= timeBetweenAttacks)
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
                c.gameObject.GetComponent<Health>().TakeDamage(spearDamage);
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stabRange);
    }
}
