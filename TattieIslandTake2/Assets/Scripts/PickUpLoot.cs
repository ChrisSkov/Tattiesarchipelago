using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLoot : MonoBehaviour
{
    GameObject player;
    float pickUpDistance = 1.5f;

    public Player playerScriptObj;
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
           playerScriptObj.resources.woodCount +=1;
           Destroy(gameObject);
        }

    }
}
