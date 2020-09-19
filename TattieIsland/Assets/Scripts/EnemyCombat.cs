using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab = null;
    [SerializeField] float fireballDamage = 10f;
    [SerializeField] float fireballSpeed = 10f;
    [SerializeField] float timeBetweenFireballs = 2f;
    [SerializeField] float destroyTimeAfterHit = 1f;
    [SerializeField] Transform fireballSocket = null;
    [SerializeField] float playerInCombatRange = 8f;
    [SerializeField] float playerInFollowRange = 12f;
    [SerializeField] float timer = Mathf.Infinity;

    Transform player;
    Animator anim;
    AIPath path;
    void Start()
    {
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(gameObject.transform.position, player.position) <= playerInFollowRange)
        {
            path.destination = player.position;
        }
        if (timer >= timeBetweenFireballs && Vector3.Distance(gameObject.transform.position, player.position) <= playerInCombatRange)
        {
            Fire();
        }
    }

    public void Fire()
    {
        timer = 0f;
        fireballSocket.LookAt(player.position);
        GameObject clone = Instantiate(fireballPrefab, fireballSocket.position, fireballSocket.rotation);
        clone.GetComponent<Rigidbody>().AddForce(fireballSocket.transform.forward * fireballSpeed, ForceMode.Impulse);
        clone.GetComponent<FireBallHit>().SetDamage(fireballDamage);
        clone.GetComponent<FireBallHit>().SetDestroyAfterHit(destroyTimeAfterHit);
    }




}
