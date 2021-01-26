using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ChickenBehavior : MonoBehaviour
{
    AIPath path;
    public ChickenScriptObj chicken;
    public float eggTimer = 0f;
    float timeBetweenEggs;
    public Transform nest;
    bool atNest;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenEggs = chicken.layEggTime + Random.Range(1,10);
        path = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        eggTimer += Time.deltaTime;
        if (Vector3.Distance(nest.position, transform.position) <= 0.5f)
        {
            atNest = true;
        }
        else
        {
            atNest = false;
        }
        if (eggTimer >= timeBetweenEggs)
        {
            if (!atNest)
            {
                path.destination = nest.position;
            }
            else if (atNest)
            {

                Instantiate(chicken.eggPrefab, transform.position, transform.rotation);
                eggTimer = 0f;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        if (other.gameObject.layer == mask)
        {

        }
    }
}
