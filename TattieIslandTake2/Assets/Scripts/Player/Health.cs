using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player player;
    public Transform bloodPos;

    public GameObject deathScreen;
    bool hasTriggeredDeath = false;

    public float regenTimer = 0f;
    public float timeBetweenRegen = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player.stats.currentHealth.statValue = player.stats.maxHealth.statValue;
        player.isDead = false;
        player.canAttack = true;
        player.canMove = true;
    }
    private void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer >= timeBetweenRegen && player.stats.currentHealth.statValue < player.stats.maxHealth.statValue && !player.isDead)
        {
            player.stats.currentHealth.statValue += Mathf.RoundToInt((player.stats.maxHealth.statValue / 100));
            regenTimer = 0f;
        }
    }
    public void TakeDamage(float damage)
    {
        player.stats.currentHealth.statValue -= damage;
        GetComponent<AudioSource>().PlayOneShot(player.playerAudio.takeDamageSounds[Random.Range(0, player.playerAudio.takeDamageSounds.Length)]);
        if (player.stats.currentHealth.statValue <= 0)
        {
            player.stats.currentHealth.statValue = 0;
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
