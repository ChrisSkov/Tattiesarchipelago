using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChickenInfo : MonoBehaviour
{
    public Slider hpBar;
    Text nameText;
    public ChickenScriptObj stats;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<Slider>();
        nameText = GetComponentInChildren<Text>();
        hpBar.maxValue = stats.maxHp;
        hpBar.value = stats.maxHp;
        nameText.text = stats.chickenNames[Random.Range(0, stats.chickenNames.Length)];

    }


    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
    }
}
