using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLoot : MonoBehaviour
{
    public Player playerScriptObj;
    public ResourceScriptObj myLoot;
    GameObject player;

    float pickUpDistance = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= pickUpDistance && Input.GetKeyDown(KeyCode.E))
        {
            myLoot.resourceCount += 1;
            Destroy(gameObject);
        }

    }
}
