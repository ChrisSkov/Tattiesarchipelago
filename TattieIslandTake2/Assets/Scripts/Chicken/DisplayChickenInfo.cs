using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChickenInfo : MonoBehaviour
{
    public Slider hpBar;
    Text nameText;
    public Text hpText;
    public ChickenScriptObj stats;
    ChickenHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<ChickenHealth>();
        hpBar = GetComponentInChildren<Slider>();
        nameText = GetComponentInChildren<Text>();
        hpBar.maxValue = stats.maxHp;
        hpBar.value = stats.maxHp;
        nameText.text = stats.chickenNames[Random.Range(0, stats.chickenNames.Length)];
        UpdateHealthBar(stats.maxHp);
    }


    public void UpdateHealthBar(float currentHp)
    {
        hpBar.value = currentHp;
        hpText.text = string.Format("{0}/{1}", Mathf.RoundToInt(health.currentHp), Mathf.RoundToInt(stats.maxHp));

    }
}
