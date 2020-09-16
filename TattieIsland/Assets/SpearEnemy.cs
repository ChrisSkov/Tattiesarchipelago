using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SpearEnemy : MonoBehaviour
{
    Transform player;
    Animator anim;
    AIPath path;
    [SerializeField] float timer = Mathf.Infinity;
    [SerializeField] float timeBetweenAttacks = 1.5f;
    [SerializeField] float stabRange = 8f;
    [SerializeField] float chaseRange = 12f;
    [SerializeField] float kiteThreshold = 1f;
    [SerializeField] float kiteBackDistance = 1f;
    [SerializeField] float spearDamage = 12f;
    // [SerializeField] float distanceBeforeFacingPlayer = 12f;
    [SerializeField] Collider spearCollider;

    // Start is called before the first frame update
    void Start()
    {
        spearCollider = GetComponentInChildren<SphereCollider>();
        spearCollider.enabled = false;
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //  path.endReachedDistance = stabRange;
        timer += Time.deltaTime;
        if (InChaseRange())
        {
            path.destination = player.position;
        }

        StabBehavior();
        KiteBehavior();
        //DestinationBehavior();
    }

    private void KiteBehavior()
    {
        bool isKiting = false;
        if (InKiteRange() && !isKiting)
        {
            isKiting = true;
            Vector3 transformDirectionVector = new Vector3(transform.position.x, 0, transform.position.z + kiteBackDistance);
            Vector3 kiteDestination = transform.position + player.TransformDirection(transformDirectionVector);
            path.destination = kiteDestination;
            if (path.destination == kiteDestination && path.reachedEndOfPath)
            {
                path.destination = player.position;
            }

        }
    }

    private void StabBehavior()
    {
        if (timer >= timeBetweenAttacks && InStabRange() && !InKiteRange())
        {
            path.isStopped = true;
            timer = 0f;
            anim.SetTrigger("stab");
            anim.SetBool("idle", false);
            spearCollider.enabled = true;
        }
        else
        {
            path.isStopped = false;
        }
        if (timer < timeBetweenAttacks)
        {
            anim.SetBool("idle", true);
        }
    }

    // private void DestinationBehavior()
    // {
    //     if (path.destination == player.position)
    //     {
    //         path.whenCloseToDestination = CloseToDestinationMode.Stop;
    //     }
    //     else
    //     {
    //         path.whenCloseToDestination = CloseToDestinationMode.ContinueToExactDestination;
    //     }
    // }

    private bool InKiteRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= kiteThreshold;
    }

    private bool InStabRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= stabRange;
    }

    bool InChaseRange()
    {
        return Vector3.Distance(gameObject.transform.position, player.position) <= chaseRange;
    }



    void TurnOnCollider()
    {
        spearCollider.enabled = true;
    }
    void TurnOffCollider()
    {
        spearCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        Collider myCollider = other.contacts[0].thisCollider;
        if (other.gameObject == player.gameObject && myCollider == spearCollider)
        {
            print(myCollider.name);
            other.gameObject.GetComponent<Health>().TakeDamage(spearDamage);
            TurnOffCollider();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, stabRange);
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, kiteThreshold);
        Gizmos.DrawWireSphere(transform.position, kiteBackDistance);
    }
}
