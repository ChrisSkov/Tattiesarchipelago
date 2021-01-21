using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryChicken : MonoBehaviour
{
    public Player player;
    public ChickenScriptObj chicken;
    public Transform carryPos;
    Animator anim;

    public Transform fire;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player.carryPosition = carryPos;
        player.carryChicken = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.carryChicken)
        {
            if (!anim.GetBool("carry"))
            {
                anim.SetBool("carry", true);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.carryChicken = false;
            }
            if (Vector3.Distance(fire.transform.position, player.carryPosition.position) <= 2f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject chickenObj = player.carryPosition.GetChild(0).gameObject;
                    player.stats.currentHealth.statValue += chickenObj.GetComponent<ChickenHealth>().currentHp / 3;
                    chicken.chickenResource.updateMe = true;
                    Destroy(chickenObj,0.2f);
                    player.carryChicken = false;
                }
            }
        }
        else
        {
            anim.SetBool("carry", false);
        }
    }
}
