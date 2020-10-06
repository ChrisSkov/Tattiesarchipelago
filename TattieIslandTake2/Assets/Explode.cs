using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public bool startExplosionTimer = false;
    public GameObject explosionVFX = null;
    public float timer = 0f;
    public float timeBeforeBoom = 1f;
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
            if (timer >= timeBeforeBoom)
            {
                Instantiate(explosionVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
