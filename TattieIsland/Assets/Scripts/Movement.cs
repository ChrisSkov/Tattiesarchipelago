using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    Rigidbody playerRB;
    Vector3 moveDirection = Vector3.zero;
    Animator playerAnim;
    Vector3 mouseWorldPositon = Vector3.zero;
    float runTimer = Mathf.Infinity;

    AudioSource source;
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
        PlayWalkSound();
    }

    private void PlayWalkSound()
    {
        runTimer += Time.deltaTime;
        if (playerAnim.GetBool("isRunning") && runTimer >= stats.stepSoundDelay)
        {
            runTimer = 0;
            source.PlayOneShot(stats.walkSound);
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
        moveDirection *= stats.moveSpeed;
        //Move
        playerRB.MovePosition(playerRB.position + moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        //Rotation

        //Set up hit, ray and mask for raycast
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Ground");

        //execute raycast and calculate mouse position
        Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
        mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;

        //rotate the player accordingly
        transform.rotation = Quaternion.LookRotation(mouseWorldPositon, Vector3.up);

    }
}
