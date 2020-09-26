using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnemyHealth : MonoBehaviour
{
    Slider hpBar;
    Text hpText;
    public EnemyStats stats;


    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<Slider>();
        hpText = GetComponentInChildren<Text>();
    }

    public void SetHPBarMaxValue(float maxHP)
    {
        hpBar.maxValue = maxHP;
    }


    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
        hpText.text = string.Format("{0}/{1}", Mathf.RoundToInt(currentHp), Mathf.RoundToInt(stats.maxHp));
    }


}
