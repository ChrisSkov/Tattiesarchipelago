using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    public ChickenScriptObj chicken;
    public float eggTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        eggTimer += Time.deltaTime;
        if (eggTimer >= chicken.layEggTime)
        {
            Instantiate(chicken.eggPrefab, transform.position, transform.rotation);
            eggTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        if(other.gameObject.layer == mask)
        {
            
        }
    }
}
