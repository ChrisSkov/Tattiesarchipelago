using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStats stats = null;
    [SerializeField] GameObject shatterObject = null;
    [SerializeField] ParticleSystem bloodSpray = null;
    [SerializeField] AudioClip deathSound = null;
    Animator anim;
    public float currentHp;
    public bool isDead = false;
    Transform particleHolder;
    Transform playerTransform;
    DisplayEnemyHealth health;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        particleHolder = transform.GetChild(1).GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHp = stats.maxHp;

        health = GetComponent<DisplayEnemyHealth>();
        health.SetHPBarMaxValue(stats.maxHp);
        health.UpdateHealthBar(currentHp);
    }
    private void Update()
    {
        HandleDeath();
    }

    //anim event
    void DeathAnimEvent()
    {
        source.PlayOneShot(deathSound);
        particleHolder.transform.LookAt(playerTransform);
        Instantiate(bloodSpray, particleHolder.position, particleHolder.rotation);
        Instantiate(shatterObject, transform.position, transform.rotation);
        DespawnEnemy();

    }

    public bool IsDead()
    {
        return currentHp <= 0;
    }
    void HandleDeath()
    {
        if (IsDead() && !isDead)
        {
            currentHp = 0;
            isDead = true;
            anim.SetTrigger("isDead");
        }
    }
    void DespawnEnemy()
    {
        Destroy(gameObject, stats.destroyTime);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        health.UpdateHealthBar(currentHp);
    }
}
