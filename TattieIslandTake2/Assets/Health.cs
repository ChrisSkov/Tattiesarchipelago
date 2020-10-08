using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerStats stats;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(stats.currentHealth <= 0)
        {
            stats.currentHealth = 0;
            stats.isDead = true;
            stats.canAttack = false;
            stats.canMove = false;
        }
    }

    public void TakeDamage(float damage)
    {
        stats.currentHealth -= damage;
    }
}
