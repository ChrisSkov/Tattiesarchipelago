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
    RawImage myImage;
    GameObject indicatorClone = null;
    bool hasEnoughWood;
    bool hasEnoughPotato;
    public AstarPath path;

    DisablePlacementOnHover hover;
    // Start is called before the first frame update
    void Start()
    {
        hover = GetComponentInParent<DisablePlacementOnHover>();
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
            hasEnoughPotato = true;
        }
        else
        {
            potatoPriceText.color = Color.red;
            hasEnoughPotato = false;

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

        if (hasEnoughPotato && hasEnoughWood)
        {
            myBuilding.canAfford = true;
        }
        else
        {
            myBuilding.canAfford = false;
        }


        if (indicatorClone != null)
        {
            indicatorClone.transform.position = myBuilding.player.mouseWorldPosition;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                myBuilding.player.currentlySelectedBuilding = null;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && myBuilding.canAfford && indicatorClone.GetComponent<BuildingPlacement>().canPlace && hover.hoverUI == false)
            {
                myBuilding.PlaceBuilding();
                path.Scan();
            }
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
