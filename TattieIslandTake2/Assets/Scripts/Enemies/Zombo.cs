using System.Collections;
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
    public bool canRotate = true;

    public float specialAttackTimer = 0f;
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
                    if (canRotate)
                    {
                        transform.LookAt(player.position);
                    }
                    path.destination = player.position;
                    if (Vector3.Distance(transform.position, player.position) <= zomboStats.attackRange)
                    {

                        ChooseAttack();

                    }
                }
            }

        }
    }


    void ChooseAttack()
    {
        if (specialAttackTimer >= zomboStats.timeBetweenSpecialAttack && attackTimer >= zomboStats.timeBetweenAttacks)
        {
            if (Random.Range(0, 3) <= 1)
            {
                anim.SetTrigger("acidSpray");
                specialAttackTimer = 0f;
            }
            else
            {
                anim.SetTrigger("attack");
                attackTimer = 0f;
            }

        }
        else if (attackTimer >= zomboStats.timeBetweenAttacks)
        {
            anim.SetTrigger("attack");
            attackTimer = 0f;
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
                source.volume = 0.3f;
                c.gameObject.GetComponent<Health>().TakeDamage(zomboStats.damage);
                source.PlayOneShot(zomboStats.hitSound);
            }
        }
    }

    void AcidSprayChargeUp()
    {
        source.volume = 0.8f;
        source.PlayOneShot(zomboStats.acidSprayChargeUpSounds[Random.Range(0, zomboStats.acidSprayChargeUpSounds.Length)]);
    }


    void AcidSprayAnimEvent()
    {
        GameObject acidClone = Instantiate(acidSpray, acidSprayAim.position, acidSprayAim.rotation);
        acidClone.transform.SetParent(acidSprayAim);
        GameObject acidCone = Instantiate(acidSprayCone, acidSprayAim.position, acidSprayAim.rotation);
        acidCone.transform.SetParent(acidSprayAim);

        source.PlayOneShot(zomboStats.acidSpraySounds[Random.Range(0, zomboStats.acidSpraySounds.Length)]);
        Destroy(acidClone, 1f);
        Destroy(acidCone, 1f);
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
