using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class BuildingHealth : MonoBehaviour
{

    public BuildingScriptObj myBuilding;

    public float currentHealth;
    public bool isDead = false;
    public UpdateGraph graph;

    public Slider hpBar;
    bool isScanning = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = myBuilding.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.maxValue = myBuilding.maxHealth;
        hpBar.value = currentHealth;

        if (isDead)
        {
            print("Building Scanning");
            if (!isScanning)
            {
                graph.GraphUpdate();
                isScanning = true;
            }
            Destroy(gameObject);
        }


    }

    public void BuildingTakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }
}
