using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public bool startExplosionTimer = false;
    public GameObject explosionVFX = null;
    public float timer = 0f;
    public float timeBeforeBoom = 1f;
    public WeaponAbstract stats;
    bool hasBlownUp = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startExplosionTimer)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeBoom && !hasBlownUp)
            {
                hasBlownUp = true;
                Instantiate(explosionVFX, transform.position, transform.rotation);
                LayerMask mask = LayerMask.GetMask("Enemy");
                RaycastHit hit;
                foreach (Collider c in Physics.OverlapSphere(transform.position, stats.range, mask))
                {
                    Debug.Log("hit with dyNaMite");
                    if (Physics.Raycast(transform.position, c.gameObject.transform.position - transform.position, out hit, mask))
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * stats.force, ForceMode.Impulse);

                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
