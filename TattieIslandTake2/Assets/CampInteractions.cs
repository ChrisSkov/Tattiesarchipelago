using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampInteractions : MonoBehaviour
{
    public Player player;
    Transform playerPos;
    public GameObject fire;

    ShowInfoOnHover hover;
    // Start is called before the first frame update
    void Start()
    {
        hover = GetComponentInChildren<ShowInfoOnHover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.carryChicken)
        {
            hover.enabled = true;
            if (Vector3.Distance(fire.transform.position, player.carryPosition.position) <= 2f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject chicken = player.carryPosition.GetChild(0).gameObject;
                    player.stats.currentHealth.statValue +=chicken.GetComponent<ChickenHealth>().currentHp/3;

                    Destroy(chicken);
                }
            }
        }
        else
        {
            hover.enabled = false;
        }
    }
}
