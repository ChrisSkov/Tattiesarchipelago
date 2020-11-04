using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ZomboAbstract stats = null;
    [SerializeField] GameObject shatterObject = null;
    [SerializeField] ParticleSystem bloodSpray = null;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] Transform organHolder = null;
    [SerializeField] Player player = null;
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
        //TODO get organ array from zombo stats. instantiate amount of organs based on damage taken. apply force to instantiated organs
        GameObject organs = Instantiate(shatterObject, organHolder.position, organHolder.rotation);

        organs.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 3, ForceMode.Impulse);
        source.PlayOneShot(deathSound);
        particleHolder.transform.LookAt(playerTransform);
        Instantiate(bloodSpray, particleHolder.position, particleHolder.rotation);
        player.progression.currentXP += stats.xpGrantedOnDeath;
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
