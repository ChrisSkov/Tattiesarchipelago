using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class PickUpChicken : MonoBehaviour
{
    public ShowInfoOnHover hover;
    Transform playerPos;
    public ChickenScriptObj chicken;
    public Player player;
    Animator anim;
    AIPath path;
    // Start is called before the first frame update
    void Start()
    {

        path = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        hover = GetComponent<ShowInfoOnHover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hover.isHover && Vector3.Distance(gameObject.transform.position, playerPos.position) <= chicken.pickUpRange)
        {
            PickUp();
        }

        PutDown();
    }
    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            path.enabled = false;
            player.carryChicken = true;
            anim.SetBool("isCarry", true);
            transform.SetParent(player.carryPosition);
            GetComponent<CapsuleCollider>().enabled = false;
            transform.position = player.carryPosition.position;
        }
    }
    private void PutDown()
    {
        if (anim.GetBool("isCarry"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                path.enabled = true;
                path.destination = transform.position;
                transform.SetParent(null);
                player.carryChicken = false;
                anim.SetBool("isCarry", false);
                GetComponent<CapsuleCollider>().enabled = true;

            }
        }
    }


}
