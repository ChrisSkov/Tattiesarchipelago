using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySavage : MonoBehaviour
{

    Animator anim;
    AIPath path;
    Transform player;
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
        path.destination = player.position;
        if (path.isStopped == false)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
