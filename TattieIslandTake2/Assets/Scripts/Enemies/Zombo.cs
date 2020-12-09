
using UnityEngine;
using Pathfinding;

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
    public float attackTimer = Mathf.Infinity;
    Transform playerTransform;
    public Transform currentTarget;
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
        //If zombie is alive
        if (!health.isDead)
        {
            //and player is dead      
            if (player.stats.currentHealth.statValue <= 0)
            {
                //stop and dance          
                path.isStopped = true;
                transform.LookAt(Camera.main.transform.GetChild(0).transform.position);
                anim.SetTrigger("victory");
            }
            else
            {
                //increment the attack timer
                attackTimer += Time.deltaTime;
                HandleMoveAnim();
                //if distance to player is less than or equal to zombie chase range
                if (Vector3.Distance(transform.position, playerTransform.position) <= zomboStats.chaseRange)
                {
                    //set current target to player   
                    currentTarget = playerTransform;
                    //if there is no viable path to the player
                    if (path.reachedEndOfPath == true || path.hasPath == false || path.isStopped || currentTarget == playerTransform && anim.GetFloat("forwardSpeed") <= 0.25f)
                    {
                        RaycastHit hit;
                        LayerMask mask = LayerMask.GetMask("Obstacle");
                        if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, mask))
                        {
                            if (hit.collider.gameObject.tag == "Building")
                            {
                                currentTarget = hit.transform;
                            }
                        }
                    }

                    if (canRotate)
                    {
                        //look at the target
                        transform.LookAt(currentTarget.position);
                    }
                    //go to the target
                    path.destination = currentTarget.position;

                    //are we close enough to attack?
                    if (Vector3.Distance(transform.position, currentTarget.position) <= zomboStats.attackRange)
                    {
                        //is it time to attack?
                        if (attackTimer >= zomboStats.timeBetweenAttacks)
                        {
                            //do we have special attack animations?
                            if (zomboStats.animOverride != null)
                            {
                                anim.runtimeAnimatorController = zomboStats.animOverride;
                            }
                            //attack currentTarget and reset attack timer
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
        if (currentTarget != playerTransform && Vector3.Distance(transform.position, playerTransform.position) > Vector3.Distance(transform.position, currentTarget.position))
        {
            zomboStats.AttackConstruction(aim, source);
        }
        else
        {
            zomboStats.Attack(aim, source);
        }
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
