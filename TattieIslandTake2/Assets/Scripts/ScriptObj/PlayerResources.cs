using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerResources", order = 2)]
public class PlayerResources : ScriptableObject
{
    public int moneyCount;
    public int chickenCount;
    public int ammoCount;
    public int dynamiteCount;
}
