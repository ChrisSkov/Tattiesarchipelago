using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnemyHealth : MonoBehaviour
{
    public EnemyStats stats;
    Slider hpBar;
    public EnemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        hpBar = GetComponentInChildren<Slider>();
        hpBar.maxValue = stats.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = health.currentHp;
    }
}
