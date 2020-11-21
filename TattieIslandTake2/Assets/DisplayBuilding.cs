﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBuilding : MonoBehaviour
{
    public BuildingScriptObj myBuilding;
    public Text nameText;
    public Text potatoPriceText;
    public Text woodPriceText;
    RawImage myImage;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<RawImage>();
        potatoPriceText.text = "X " + myBuilding.price;
        woodPriceText.text = "X " + myBuilding.woodReq;
        nameText.text = myBuilding.buildingName;
        myImage.texture = myBuilding.uiImage;
    }

    // Update is called once per frame
    void Update()
    {

        if (myBuilding.player.resources.potatoCount >= myBuilding.price)
        {
            potatoPriceText.color = Color.white;

            if (myBuilding.player.resources.woodCount >= myBuilding.woodReq)
            {
                woodPriceText.color = Color.white;

                myBuilding.canAfford = true;
            }
            else
            {
                woodPriceText.color = Color.red;
            }
        }
        else
        {
            potatoPriceText.color = Color.red;
        }

    }
}
