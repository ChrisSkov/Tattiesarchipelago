using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseConsumable : MonoBehaviour
{
    public Player player;
    AudioSource  source;
    public GameObject[] consumables;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(player.resources.healthPotCount >= 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.activeConsumable.ConsumeItem(source);
        }
    }
}
