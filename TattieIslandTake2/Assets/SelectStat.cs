using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStat : MonoBehaviour

{
    public Player player;
    LevelUpStats levelUpStats;
    public StatScriptObj myStat;
    public Text myStatText;
    int statIncreaseCount;
    private void Start()
    {
        levelUpStats = GetComponentInParent<LevelUpStats>();
        myStatText.text = "" + myStat.statValue + "(" + myStat.increasePerLevel + ")";
        myStat.newValue = myStat.statValue;
    }

    public void IncreaseMyStat()
    {
        if (player.progression.attributePoints > 0)
        {
            statIncreaseCount++;
            levelUpStats.AddToStatIncreaseList(myStat);
            myStat.newValue += myStat.increasePerLevel;
            myStatText.text = "" + myStat.newValue + "(+" + myStat.increasePerLevel + ")";
        }
    }


    public void DecreaseMyStat()
    {
        if (myStat.newValue > myStat.statValue)
        {
            statIncreaseCount--;
            myStat.newValue -= myStat.increasePerLevel;
            levelUpStats.ReturnAttributePoint();
        }
        myStatText.text = "" + myStat.newValue + "(" + myStat.increasePerLevel + ")";
    }
}
