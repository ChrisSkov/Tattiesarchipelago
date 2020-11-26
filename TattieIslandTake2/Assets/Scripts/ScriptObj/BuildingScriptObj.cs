using UnityEngine.UI;
using UnityEngine;
[CreateAssetMenu]
public class BuildingScriptObj : ScriptableObject
{
    public GameObject prefab;
    public GameObject indicatorPrefab;
    public Texture2D uiImage;
    public string buildingName;
    public int price;
    public int woodReq;
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
        }

    }

}
