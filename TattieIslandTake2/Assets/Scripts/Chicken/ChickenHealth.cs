using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHealth : MonoBehaviour
{
    public ChickenScriptObj chickenStats;

    public float currentHp = 50f;
    public float currentHungerLevel = 0f;
    public float layEggCountDown;
    public float currentEnemyFear;
    public float layEggTimer;
    public float healthRegenTimer;
    DisplayChickenInfo chickenInfo;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = chickenStats.maxHp;
        currentEnemyFear = chickenStats.fearOfEnemies;
        chickenInfo = GetComponent<DisplayChickenInfo>();
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
