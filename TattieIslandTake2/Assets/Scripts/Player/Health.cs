using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player player;
    public Transform bloodPos;

    public GameObject deathScreen;
    bool hasTriggeredDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        player.stats.currentHealth = player.stats.maxHealth;
        player.isDead = false;
        player.canAttack = true;
        player.canMove = true;
    }

    public void TakeDamage(float damage)
    {
        player.stats.currentHealth -= damage;
        GetComponent<AudioSource>().PlayOneShot(player.playerAudio.takeDamageSounds[Random.Range(0, player.playerAudio.takeDamageSounds.Length)]);
        if (player.stats.currentHealth <= 0)
        {
            player.stats.currentHealth = 0;
            player.isDead = true;
            player.canAttack = false;
            player.canMove = false;
            if (!hasTriggeredDeath)
            {
                deathScreen.SetActive(true);
                GetComponent<Animator>().SetTrigger("isDead");
                GetComponent<AudioSource>().PlayOneShot(player.playerAudio.deathSound);
                hasTriggeredDeath = true;
            }
        }
        GameObject bloodClone = Instantiate(player.blood, bloodPos.position, bloodPos.rotation);
        Destroy(bloodClone, 0.5f);
    }
}
