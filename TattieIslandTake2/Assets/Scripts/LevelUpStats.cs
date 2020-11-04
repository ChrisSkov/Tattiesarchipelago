using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{
    public Player player;

    public Text attributePointText = null;
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attributePointText.text = "Attribute Points: " + player.progression.attributePoints;
    }

    public void AcceptChanges()
    {
        gameObject.SetActive(false);
    }


    public void LevelUpDmg()
    {
        player.stats.dmgModifier += 1;
        player.progression.attributePoints -= 1;

    }
    public void LevelUpMoveSpeed()
    {
        player.stats.maxMoveSpeed += 1;
        player.progression.attributePoints -= 1;

    }

    public void LevelUpHealth()
    {
        player.stats.maxHealth += 30;
        player.progression.attributePoints -= 1;
    }
}
