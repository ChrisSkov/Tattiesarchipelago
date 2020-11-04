using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{
    public Player player;
    public Text attributePointText = null;
    StatScriptObj chosenStat;


    void Update()
    {
        attributePointText.text = "Attribute Points: " + player.progression.attributePoints;
    }

    public void StatIncrease(StatScriptObj statToIncrease)
    {
        chosenStat = statToIncrease;
        statToIncrease.statValue += statToIncrease.increasePerLevel;
        player.progression.attributePoints -= 1;

    }
    public void AcceptChanges()
    {
        gameObject.SetActive(false);
    }

    public void CancelChanges()
    {
        chosenStat.statValue -= chosenStat.increasePerLevel;
        player.progression.attributePoints += 1;
        gameObject.SetActive(false);

    }

    // public void LevelUpDmg()
    // {
    //     player.stats.dmgModifier.statValue += 1;
    //     player.progression.attributePoints -= 1;

    // }
    // public void LevelUpMoveSpeed()
    // {
    //     player.stats.maxMoveSpeed.statValue += 1;
    //     player.progression.attributePoints -= 1;

    // }

    // public void LevelUpHealth()
    // {
    //     player.stats.maxHealth.statValue += 30;
    //     player.progression.attributePoints -= 1;
    // }
}
