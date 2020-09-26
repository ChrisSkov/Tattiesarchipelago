using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStats stats = null;
    [SerializeField] GameObject shatterObject = null;
    [SerializeField] GameObject[] enemyPhysicsObjects = new GameObject[7];
    [SerializeField] SkinnedMeshRenderer mesh = null;
    [SerializeField] ParticleSystem bloodSpray = null;
    [SerializeField] AudioClip deathSound = null;
    Animator anim;
    public float currentHp;
    public bool isDead = false;
    Transform particleHolder;
    bool hasSpawnedShatter = false;
    bool bloodHasPlayed = false;
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
    void SpawnShatterObject()
    {
        if (isDead && !hasSpawnedShatter && !bloodHasPlayed)
        {

            //Loop through objects that enemy wears that need to be affected by physics
            foreach (GameObject g in enemyPhysicsObjects)
            {
                //Enable their collider and add rigidbody so they go flying
                g.GetComponent<Collider>().enabled = true;
                g.AddComponent<Rigidbody>();
            }

            //disable main character mesh
            mesh.enabled = false;
            //Get ready to spray blood everywhere
            particleHolder.transform.LookAt(playerTransform);
            //BLOOD FOR THE BLOOD GODS!
            Instantiate(bloodSpray, particleHolder.position, particleHolder.rotation);
            source.PlayOneShot(deathSound);
            bloodHasPlayed = true;
            //Shatter into pieces
            //    Instantiate(shatterObject, transform.position, transform.rotation);
            hasSpawnedShatter = true;
            //Despawn the mess we just made
            DespawnEnemy();
        }
    }

    void DespawnEnemy()
    {
        Destroy(gameObject, stats.destroyTime);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            isDead = true;
            SpawnShatterObject();
        }
        health.UpdateHealthBar(currentHp);
    }
}
