﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskBehavior : MonoBehaviour
{

    public TaskAbstract task;
    public Player playerScriptObj;
    public Transform player;
    public int currentHealth;
    public Animator playerAnim;
    PerformTask performTask;
    public Slider hpBar;
    bool canDoTask = true;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = task.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnim = player.gameObject.GetComponent<Animator>();
        performTask = player.gameObject.GetComponent<PerformTask>();
        hpBar.maxValue = task.maxHealth;
        hpBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= task.distanceToStart)
        {
            if (Input.GetKeyDown(KeyCode.E) && canDoTask)
            {

                hpBar.gameObject.SetActive(true);
                performTask.currentTaskObject = gameObject;
                playerScriptObj.currentTaskObj = task;
                playerAnim.runtimeAnimatorController = task.animOverride;
                task.OnTaskBegin(playerAnim, performTask.handAimRight);
            }
        }


        if (Vector3.Distance(transform.position, player.position) >= task.distanceToExit)
        {
            canDoTask = false;
        }
        if (currentHealth <= 0)
        {
            canDoTask = false;
            task.OnTaskComplete(GetComponent<Animator>());
        }
        if (!canDoTask)
        {
            playerScriptObj.currentTaskObj = null;
        }

        hpBar.value = currentHealth;
    }

}
