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
     //   HandleDeath();
    }


    bool IsDead()
    {
        return currentHp <= 0f;
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
    void HandleDeath()
    {
        if (IsDead() && !isDead)
        {
            isDead = true;
            currentHp = 0;
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
        if (currentHp > 0)
        {
            anim.SetTrigger("isHit");
        }
        else if (IsDead())
        {
            anim.SetTrigger("isDead");

        }
        health.UpdateHealthBar(currentHp);
    }
}
