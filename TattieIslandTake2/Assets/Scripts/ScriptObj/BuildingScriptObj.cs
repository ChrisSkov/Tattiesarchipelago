using UnityEngine.UI;
using UnityEngine;
[CreateAssetMenu]
public class BuildingScriptObj : ScriptableObject
{
    [Header("Attributes")]
    // Name of the building
    public string buildingName;

    // The actual in-game model of the building
    public GameObject prefab;
    
    // The model used as indicator of legal/illegal placement
    public GameObject indicatorPrefab;

    // Icon for UI
    public Texture2D uiImage;

    // How much damage can the building take?
    public float maxHealth;

    [Header("Price")]
    public int price;
    public int woodReq;
    public int stoneReq;
    public float deliveryTime;
    public bool canAfford;

    public Player player;



    public void PlaceBuilding(Transform indicatorTransform)
    {
        if (canAfford)
        {
            Instantiate(prefab, player.mouseWorldPosition, indicatorTransform.rotation);
            player.resources.wood.resourceCount -= woodReq;
            player.resources.potato.resourceCount -= price;
            player.resources.stone.resourceCount -= stoneReq;
            player.resources.wood.updateMe = true;
            player.resources.potato.updateMe = true;
            player.resources.stone.updateMe = true;
        }

    }

}
