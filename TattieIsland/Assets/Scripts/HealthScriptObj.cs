using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptObj : MonoBehaviour
{
    public PlayerStats stats;


    float timer = Mathf.Infinity;
    private void Start()
    {
        stats.currentHp = stats.maxHp;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        RegenHealth();
    }

    private void RegenHealth()
    {
        if (timer >= stats.healthRegenTime)
        {
            timer = 0;
            stats.currentHp += stats.healthRegen;
        }
    }

    public void TakeDamage(float damage)
    {
        stats.currentHp -= damage;
    }

}
