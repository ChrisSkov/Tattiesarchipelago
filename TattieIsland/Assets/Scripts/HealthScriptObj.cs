using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptObj : MonoBehaviour
{
    [Header("Stats")]
    public PlayerStats stats;
    [Header("Audio")]
    public AudioClip deathSound = null;
    public AudioClip[] takeDamageSound = null;
    [Header("Effects stuff")]
    public Transform particleHolder;
    public ParticleSystem bloodSpray;
    public GameObject deathScreen;
    float timer = Mathf.Infinity;
    bool hasStartedDeathAnim = false;
    Animator anim;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        stats.currentHp = stats.maxHp;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        HandleHealth();

    }

    private void HandleHealth()
    {
        if (stats.currentHp <= 0)
        {
            stats.currentHp = 0;
            anim.SetBool("canMove", false);
            anim.SetBool("canAttack", false);
            anim.SetBool("canShoot", false);
            anim.SetBool("canJump", false);
            anim.SetBool("canChangeWeapons", false);
            if (!hasStartedDeathAnim)
            {
                hasStartedDeathAnim = true;
                anim.SetTrigger("isDead");
            }
        }
        else
        {
            RegenHealth();
        }
    }

    void DeathAnim()
    {
        source.PlayOneShot(deathSound);
        Instantiate(bloodSpray, particleHolder.position, particleHolder.rotation);
        deathScreen.SetActive(true);
    }
    private void RegenHealth()
    {
        if (timer >= stats.healthRegenTime && stats.currentHp < stats.maxHp)
        {
            timer = 0;
            stats.currentHp += stats.healthRegen;
        }
    }

    public void TakeDamage(float damage)
    {
        source.PlayOneShot(takeDamageSound[Random.Range(0, takeDamageSound.Length)]);
        stats.currentHp -= damage;
    }

}
