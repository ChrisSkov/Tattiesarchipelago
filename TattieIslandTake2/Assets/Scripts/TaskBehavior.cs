using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehavior : MonoBehaviour
{

    public TaskAbstract task;

    public Transform player;
    public int currentHealth;
    public Animator playerAnim;
    PerformTask performTask;

    bool canDoTask = true;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = task.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnim = player.gameObject.GetComponent<Animator>();
        performTask = player.gameObject.GetComponent<PerformTask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= task.distanceToStart)
        {
            if (Input.GetKeyDown(KeyCode.E) && canDoTask)
            {

                task.OnTaskBegin(playerAnim, performTask.handAimRight);
                performTask.currentTaskObject = gameObject;
            }
        }

        if(currentHealth <= 0)
        {
            canDoTask = false;
            task.OnTaskComplete(GetComponent<Animator>());
        }
    }

}
