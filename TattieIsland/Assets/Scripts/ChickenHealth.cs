using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHealth : MonoBehaviour
{
    public ChickenScriptObj chickenStats;

    public float currentHp;
    public float currentHungerLevel = 0f;
    public float layEggCountDown;
    public float currentEnemyFear;
    public string chickenName;
    public float layEggTimer;
    public float healthRegenTimer;
    DisplayChickenInfo chickenInfo;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = chickenStats.maxHp;
        chickenName = chickenStats.chickenNames[Random.Range(0, chickenStats.chickenNames.Length)];
        currentEnemyFear = chickenStats.fearOfEnemies;
        chickenInfo = GetComponent<DisplayChickenInfo>();
        chickenInfo.SetHPBarMaxValue(chickenStats.maxHp);
        chickenInfo.UpdateHealthBar(currentHp);
        chickenInfo.DisplayChickenName(chickenName);
    }

    // Update is called once per frame
    void Update()
    {
        layEggTimer += Time.deltaTime;
        healthRegenTimer += Time.deltaTime;
        RegenHealth();
    }

    void RegenHealth()
    {
        if (currentHp < chickenStats.maxHp && healthRegenTimer >= chickenStats.hpRegenTime)
        {
            currentHp += chickenStats.hpRegen;
            healthRegenTimer = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        layEggCountDown += damage / 2f;
        currentHp -= damage;
        chickenInfo.UpdateHealthBar(currentHp);

    }
}
