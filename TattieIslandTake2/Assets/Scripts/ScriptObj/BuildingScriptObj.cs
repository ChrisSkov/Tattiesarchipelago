﻿using UnityEngine.UI;
using UnityEngine;
[CreateAssetMenu]
public class BuildingScriptObj : ScriptableObject
{
    [Header("Attributes")]
    public string buildingName;
    public GameObject prefab;
    public GameObject indicatorPrefab;
    public Texture2D uiImage;
    public float maxHealth;
    [Header("Price")]
    public int price;
    public int woodReq;
    public int stoneReq;
    public float deliveryTime;
    public bool canAfford;
    
    public Player player;



    public void PlaceBuilding()
    {
        if (canAfford)
        {
            Instantiate(prefab, player.mouseWorldPosition, prefab.transform.rotation);
            player.resources.woodCount -= woodReq;
            player.resources.potatoCount -= price;
            player.resources.stoneCount -= stoneReq;
        }

    }

}
