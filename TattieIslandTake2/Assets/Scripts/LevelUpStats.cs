using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{
    public Player player;
    public Text attributePointText = null;
    List<StatScriptObj> chosenStat = new List<StatScriptObj>();


    void Update()
    {
        attributePointText.text = "Attribute Points: " + player.progression.attributePoints;
    }

    public void AddToStatIncreaseList(StatScriptObj statToIncrease)
    {
        chosenStat.Add(statToIncrease);
        player.progression.attributePoints -= 1;

    }
    public void AcceptChanges()
    {
        foreach (StatScriptObj stat in chosenStat)
        {
            stat.statValue = stat.newValue;
        }
        gameObject.SetActive(false);
    }

    public void CancelChanges()
    {
        foreach (StatScriptObj stat in chosenStat)
        {
            stat.newValue = stat.statValue;
            ReturnAttributePoint();
        }
        gameObject.SetActive(false);

    }
    public void ReturnAttributePoint()
    {
        player.progression.attributePoints += 1;

    }

}
