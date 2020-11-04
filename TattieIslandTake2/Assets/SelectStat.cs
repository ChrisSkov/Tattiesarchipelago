using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStat : MonoBehaviour
{
    LevelUpStats levelUpStats;
    public StatScriptObj myStat;
    private void Start()
    {
        levelUpStats = GetComponentInParent<LevelUpStats>();
    }

    public void IncreaseMyStat()
    {
        levelUpStats.StatIncrease(myStat);
    }
    public void DecreaseMyStat()
    {
        levelUpStats.CancelChanges();
    }
}
