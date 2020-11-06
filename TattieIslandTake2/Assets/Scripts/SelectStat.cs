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
        UpdateStatText();
        myStat.newValue = myStat.statValue;
    }

    public void IncreaseMyStat()
    {
        if (player.progression.attributePoints > 0)
        {
            statIncreaseCount++;
            levelUpStats.AddToStatIncreaseList(myStat);
            myStat.newValue += myStat.increasePerLevel;
        }
            UpdateStatText();
    }


    public void DecreaseMyStat()
    {
        if (myStat.newValue > myStat.statValue)
        {
            statIncreaseCount--;
            myStat.newValue -= myStat.increasePerLevel;
            levelUpStats.ReturnAttributePoint();
        }
        UpdateStatText();
    }

    void UpdateStatText()
    {
        myStatText.text = "" + myStat.newValue + "(+" + myStat.increasePerLevel + ")";

    }


}
