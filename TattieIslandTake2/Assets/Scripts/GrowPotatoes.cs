using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPotatoes : MonoBehaviour
{
    public Player player;
    public int potatoesPerTick;
    public float timeBetweenPotatoes;
    public float potatoTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        potatoTimer += Time.deltaTime;

        if(potatoTimer >= timeBetweenPotatoes)
        {
            player.resources.potato.resourceCount += potatoesPerTick;
            potatoTimer = 0;
        }
    }
}
