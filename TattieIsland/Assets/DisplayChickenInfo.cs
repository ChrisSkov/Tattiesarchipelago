using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChickenInfo : MonoBehaviour
{
    Slider hpBar;
    Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<Text>();
        hpBar = GetComponentInChildren<Slider>();
    }

    public void SetHPBarMaxValue(float maxHP)
    {
        hpBar.maxValue = maxHP;
    }
    public void DisplayChickenName(string name)
    {
        nameText.text = name;
    }

    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
    }
}
