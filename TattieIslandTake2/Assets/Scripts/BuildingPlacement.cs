using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacement : MonoBehaviour
{

    public BuildingScriptObj myBuilding;
    public bool canPlace = false;
    public Canvas cannotAffordText;
    BoxCollider myBoxCollider;
    RaycastHit rayHit;
    bool hitDetection;
    public float placeRange = 4f;
    public List<GameObject> gameObjectList;

    public GameObject shop;
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        shop = GameObject.FindGameObjectWithTag("shop");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectList.Count == 0)
        {
            canPlace = true;
        }
        else
        {
            canPlace = false;
        }
        if (canPlace && myBuilding.canAfford)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            cannotAffordText.gameObject.SetActive(false);

        }
        else
        {
            cannotAffordText.gameObject.SetActive(true);
            GetComponent<MeshRenderer>().material.color = Color.red;

        }

        if(shop.activeSelf == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            gameObjectList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            gameObjectList.Remove(other.gameObject);
        }
    }

}

