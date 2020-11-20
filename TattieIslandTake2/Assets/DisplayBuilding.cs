using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBuilding : MonoBehaviour
{
    public BuildingScriptObj myBuilding;
    Text nameText;
    Text priceText;
    RawImage myImage;
    // Start is called before the first frame update
    void Start()
    {
        priceText = transform.GetChild(1).GetComponent<Text>();
        nameText = GetComponentInChildren<Text>();
        myImage = GetComponent<RawImage>();
        priceText.text = "X " + myBuilding.price;
        nameText.text = myBuilding.buildingName;
        myImage.texture = myBuilding.uiImage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
