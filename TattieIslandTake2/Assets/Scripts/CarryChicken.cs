using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryChicken : MonoBehaviour
{
    public Player player;
    public ChickenScriptObj chicken;
    public Transform carryPos;
    Animator anim;

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
        }
        else
        {
            anim.SetBool("carry", false);
        }
    }
}
