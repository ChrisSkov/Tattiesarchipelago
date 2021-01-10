using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StatScriptObj : ScriptableObject
{
    public float statValue;

    public float increasePerLevel;
    public float newValue;
    public float baseValue;

    // Reset values when starting the game
    public void ResetToBaseValue()
    {
        statValue  = baseValue;
        newValue  = baseValue;
    }
}
