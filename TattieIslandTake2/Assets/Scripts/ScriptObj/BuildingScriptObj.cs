using UnityEngine.UI;
using UnityEngine;
[CreateAssetMenu]
public class BuildingScriptObj : ScriptableObject
{
    public GameObject prefab;
    public Texture2D uiImage;
    public string buildingName;
    public int price;
    public int woodReq;
    public float deliveryTime;
    public bool canAfford;
    public Player player;


}
