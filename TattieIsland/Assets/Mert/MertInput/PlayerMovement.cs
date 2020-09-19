﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float stepSoundDelay = 0.2f;
    [SerializeField] AudioClip[] footStep = new AudioClip[3];
    Rigidbody playerRB;
    Vector3 moveDirection = Vector3.zero;
    Animator playerAnim;
    Vector3 mouseWorldPositon = Vector3.zero;
    AudioSource source;
    float runTimer = Mathf.Infinity;
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        Rotate();

    }
    private void Update()
    {
        runTimer += Time.deltaTime;
        if (playerAnim.GetBool("isRunning") && runTimer >= stepSoundDelay)
        {
            runTimer = 0;
            source.PlayOneShot(footStep[Random.Range(0, footStep.Length)]);

        }
    }
    private void HandleMovement()
    {
        //Movement
        moveDirection = new Vector3(MertInput.horizontal, 0.0f, MertInput.vertical);
        //Animation
        float angle = transform.eulerAngles.y * Mathf.Deg2Rad;

        float X = moveDirection.x * Mathf.Cos(angle) - moveDirection.z * Mathf.Sin(angle);
        float Y = moveDirection.x * Mathf.Sin(angle) + moveDirection.z * Mathf.Cos(angle);

        playerAnim.SetFloat("horizontalSpeed", X);
        playerAnim.SetFloat("forwardSpeed", Y);

        //Sikre sig at diagonal movement ikke er hurtigere
        if (moveDirection.magnitude >= 1)
        {
            moveDirection = moveDirection.normalized;
            playerAnim.SetBool("isRunning", true);

        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }

        //Sætter base speed
        moveDirection *= speed;
        //Move
        playerRB.MovePosition(playerRB.position + moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        //Rotation
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Ground");
        Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
        mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
        transform.rotation = Quaternion.LookRotation(mouseWorldPositon, Vector3.up);

    }
}
