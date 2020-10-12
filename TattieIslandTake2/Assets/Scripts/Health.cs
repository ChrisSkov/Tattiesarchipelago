using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerStats stats;
    public Transform bloodPos;

    public GameObject deathScreen;
    bool hasTriggeredDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        stats.currentHealth = stats.maxHealth;
        stats.isDead = false;
        stats.canAttack = true;
        stats.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            stats.currentHealth = 0;
            stats.isDead = true;
            stats.canAttack = false;
            stats.canMove = false;
            if (!hasTriggeredDeath)
            {
                deathScreen.SetActive(true);
                GetComponent<Animator>().SetTrigger("isDead");
                GetComponent<AudioSource>().PlayOneShot(stats.deathSound);
                hasTriggeredDeath = true;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        stats.currentHealth -= damage;
        GameObject bloodClone = Instantiate(stats.blood, bloodPos.position, bloodPos.rotation);
        Destroy(bloodClone, 0.5f);
    }
}
