using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerResources", order = 2)]
public class PlayerResources : ScriptableObject
{
    public int potatoCount;
    public int woodCount;
    public int chickenCount;
    public int stoneCount;
    public int ammoCount;
    public int dynamiteCount;
    public int healthPotCount;
}
