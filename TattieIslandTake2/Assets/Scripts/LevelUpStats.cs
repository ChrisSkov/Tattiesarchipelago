using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpStats : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LevelUpDmg()
    {
        player.stats.dmgModifier += 1;
        gameObject.SetActive(false);
    }
    public void LevelUpMoveSpeed()
    {
        player.stats.maxMoveSpeed += 1;
        gameObject.SetActive(false);
    }

    public void LevelUpHealth()
    {
        player.stats.maxHealth += 30;
        gameObject.SetActive(false);
    }
}
