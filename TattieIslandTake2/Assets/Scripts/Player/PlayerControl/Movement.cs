using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Player player = null;
    Rigidbody playerRB;
    Vector3 moveDirection = Vector3.zero;
    Animator playerAnim;
    Vector3 mouseWorldPositon = Vector3.zero;
    float runTimer = Mathf.Infinity;
    AudioSource source;

    public float X2, Y2;
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        player.stats.currentMoveSpeed.statValue = player.stats.maxMoveSpeed.statValue;
    }

    void FixedUpdate()
    {
        
        if (playerAnim.GetBool("canMove") && player.canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetTrigger("jump");
            }
            if (!player.isSlowed)
            {
                player.stats.currentMoveSpeed.statValue = player.stats.maxMoveSpeed.statValue;
            }
            HandleMovement();
            Rotate();
            PlayWalkSound();
        }

    }


    private void PlayWalkSound()
    {
        runTimer += Time.deltaTime;
        if (playerAnim.GetBool("isRunning") && runTimer >= player.stepSoundDelay)
        {
            runTimer = 0;
            source.PlayOneShot(player.playerAudio.walkSound);
        }
    }


    private void HandleMovement()
    {
        //Store horizontal and vertical input computed in "MertInput" as x and z in a vector 3
        moveDirection = new Vector3(MertInput.horizontal, 0.0f, MertInput.vertical);
        //Animation
        float angle = transform.eulerAngles.y * Mathf.Deg2Rad;

        float X = moveDirection.x * Mathf.Cos(angle) - moveDirection.z * Mathf.Sin(angle);
        float Y = moveDirection.x * Mathf.Sin(angle) + moveDirection.z * Mathf.Cos(angle);
        X2 = X;
        Y2 = Y;
        playerAnim.SetFloat("horizontalSpeed", X);
        playerAnim.SetFloat("forwardSpeed", Y);

        //Equalize strictly veritcal/horizontal speed and diagonal speed
        if (moveDirection.magnitude >= 1)
        {
            moveDirection = moveDirection.normalized;
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }

        //Speed is based on the player stat currentMoveSpeed
        moveDirection *= player.stats.currentMoveSpeed.statValue;
        //Pass the player's current position and movement vector to the actual movement function. *Time.deltaTime to ensure consistency accross framerates
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
        player.mouseWorldPosition = mouseWorldPositon + gameObject.transform.position;

    }


    void PlayJumpAudio()
    {
        source.PlayOneShot(player.jumpSounds[Random.Range(0, player.jumpSounds.Length)]);
    }
    void CanMove()
    {
        playerAnim.SetBool("canMove", true);
    }

    void CannotMove()
    {
        playerAnim.SetBool("canMove", false);
    }
}
