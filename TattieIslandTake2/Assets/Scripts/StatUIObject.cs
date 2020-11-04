using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StatUIObject : ScriptableObject
{
    public StatScriptObj myStat;


    public void IncreaseStat()
    {
       myStat.statValue += 1;
    }

}
