using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStats stats = null;
    [SerializeField] GameObject shatterObject = null;
    [SerializeField] GameObject[] enemyPhysicsObjects = new GameObject[4];
    [SerializeField] SkinnedMeshRenderer mesh = null;
    [SerializeField] ParticleSystem bloodSpray = null;
    [SerializeField] bool primitiveMesh = false;
    Transform particleHolder;
    bool hasSpawnedShatter = false;
    bool bloodHasPlayed = false;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        particleHolder = transform.GetChild(1).GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        stats.currentHp = stats.maxHp;
    }
    void Update()
    {
        particleHolder.transform.LookAt(playerTransform);
        Die();
        SpawnShatterObject();
    }

    private void Die()
    {
        if (stats.currentHp <= 0)
        {
            stats.currentHp = 0f;
            stats.isDead = true;
        }
    }

    void SpawnShatterObject()
    {
        if (stats.isDead && !hasSpawnedShatter && !bloodHasPlayed)
        {
            foreach (GameObject g in enemyPhysicsObjects)
            {
                g.GetComponent<SphereCollider>().enabled = true;
                g.GetComponent<Rigidbody>().isKinematic = false;
            }
            bloodHasPlayed = true;
            if (primitiveMesh)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                mesh.enabled = false;
            }
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            Instantiate(bloodSpray, particleHolder.position, particleHolder.rotation);
            Instantiate(shatterObject, transform.position, transform.rotation);
            hasSpawnedShatter = true;
            DespawnEnemy();
        }
    }

    void DespawnEnemy()
    {
        Destroy(gameObject, stats.destroyTime);
    }

    public void TakeDamage(float damage)
    {
        stats.currentHp -= damage;
        print("av");
    }
}
