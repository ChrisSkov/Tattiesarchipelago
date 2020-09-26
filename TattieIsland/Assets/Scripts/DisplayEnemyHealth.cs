using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnemyHealth : MonoBehaviour
{
    Slider hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<Slider>();
        print(hpBar);
    }

    public void SetHPBarMaxValue(float maxHP)
    {
        hpBar.maxValue = maxHP;
    }

    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
    }
}
