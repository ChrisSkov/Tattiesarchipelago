using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class DisplayBuilding : MonoBehaviour
{
    public BuildingScriptObj myBuilding;
    public Text nameText;
    public Text potatoPriceText;
    public Text woodPriceText;
    public Text stonePriceText;
    RawImage myImage;
    GameObject indicatorClone = null;
    bool hasEnoughWood;
    bool hasEnoughPotato;
    bool hasEnoguhStone;
    public AstarPath path;

    DisablePlacementOnHover hover;
    // Start is called before the first frame update
    void Start()
    {
        hover = GetComponentInParent<DisablePlacementOnHover>();
        myImage = GetComponent<RawImage>();
        potatoPriceText.text = "X " + myBuilding.price;
        woodPriceText.text = "X " + myBuilding.woodReq;
        stonePriceText.text = "X " + myBuilding.stoneReq;
        nameText.text = myBuilding.buildingName;
        myImage.texture = myBuilding.uiImage;

    }

    // Update is called once per frame
    void Update()
    {

        if (myBuilding.player.resources.potatoCount >= myBuilding.price)
        {
            potatoPriceText.color = Color.white;
            hasEnoughPotato = true;
        }
        else
        {
            potatoPriceText.color = Color.red;
            hasEnoughPotato = false;

        }
        if (myBuilding.player.resources.stoneCount >= myBuilding.stoneReq)
        {
            stonePriceText.color = Color.white;
            hasEnoguhStone = true;
        }
        else
        {
            stonePriceText.color = Color.red;
            hasEnoguhStone = false;

        }

        if (myBuilding.player.resources.woodCount >= myBuilding.woodReq)
        {
            woodPriceText.color = Color.white;
            hasEnoughWood = true;
        }
        else
        {
            woodPriceText.color = Color.red;
            hasEnoughWood = false;
        }

        if (hasEnoughPotato && hasEnoughWood && hasEnoguhStone)
        {
            myBuilding.canAfford = true;
        }
        else
        {
            myBuilding.canAfford = false;
        }

        //is there and active indicator?
        if (indicatorClone != null)
        {
            //indicator moves with mouse
            indicatorClone.transform.position = myBuilding.player.mouseWorldPosition;
            //right click to cancel building preview
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                myBuilding.player.currentlySelectedBuilding = null;
            }
            //if we can afford the building, it fits on the map and the mouse is not on the shop UI
            if (Input.GetKeyDown(KeyCode.Mouse0) && myBuilding.canAfford && indicatorClone.GetComponent<BuildingPlacement>().canPlace && hover.hoverUI == false)
            {
                //place the building and recreate the graph for AI movement
                myBuilding.PlaceBuilding();
                print("scanning");
                path.Scan();
            }
            //Destroy the indicator clone if the selected building is not the same as this building
            if (myBuilding.player.currentlySelectedBuilding != myBuilding)
            {
                Destroy(indicatorClone);
            }
        }
    }



    public void SelectBuilding()
    {
        if (indicatorClone != null && myBuilding.player.currentlySelectedBuilding != myBuilding)
        {
            Destroy(indicatorClone);
        }

        if (myBuilding.canAfford && indicatorClone == null || myBuilding.player.currentlySelectedBuilding != myBuilding)
        {
            indicatorClone = Instantiate(myBuilding.indicatorPrefab, myBuilding.player.mouseWorldPosition, gameObject.transform.rotation);

        }
        myBuilding.player.currentlySelectedBuilding = myBuilding;
    }
}
