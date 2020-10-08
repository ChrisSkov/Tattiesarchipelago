using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnemyHealth : MonoBehaviour
{
    public Slider hpBar;
    public Text hpText;
    public EnemyStats stats;

    public void SetHPBarMaxValue(float maxHP)
    {
        hpBar.maxValue = maxHP;
    }


    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
        if (currentHp <= 0)
        {
            currentHp = 0f;
        }
        hpText.text = string.Format("{0}/{1}", currentHp, stats.maxHp);
    }


}
