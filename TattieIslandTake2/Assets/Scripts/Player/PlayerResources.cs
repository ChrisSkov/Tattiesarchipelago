using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerResources", order = 2)]
public class PlayerResources : ScriptableObject
{
    // public int potatoCount;
    // public int woodCount;
    // public int chickenCount;
    // public int stoneCount;
    // public int ammoCount;
    // public int dynamiteCount;
    // public int healthPotCount;
    public ResourceScriptObj[] collectableResources;
    public ResourceScriptObj potato;
    public ResourceScriptObj wood;
    public ResourceScriptObj chickens;
    public ResourceScriptObj stone;
    public ResourceScriptObj ammo;
    public ResourceScriptObj dynamite;
    public ResourceScriptObj healthPot;
}
