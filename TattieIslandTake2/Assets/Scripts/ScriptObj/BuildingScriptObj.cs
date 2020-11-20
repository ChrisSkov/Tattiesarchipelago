using UnityEngine.UI;
using UnityEngine;
[CreateAssetMenu]
public class BuildingScriptObj : ScriptableObject
{
    public GameObject prefab;
    public Texture2D uiImage;
    public int price;
    public float deliveryTime;
    public bool canAfford;
}
