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
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isCarry", true);
                player.carryChicken = true;
                path.enabled = false;

                playerPos.GetComponent<Animator>().SetBool("carry", true);
                GetComponent<CapsuleCollider>().enabled = false;
                transform.SetParent(playerPos.GetChild(0).transform);
                transform.position = playerPos.GetChild(0).transform.position;
            }
        }

        if (anim.GetBool("isCarry"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GetComponent<CapsuleCollider>().enabled = true;
                anim.SetBool("isCarry", false);
                transform.SetParent(null);
                player.carryChicken = false;
                playerPos.GetComponent<Animator>().SetBool("carry", false);
                path.enabled = true;

            }
        }
    }
}
