using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidConeDamage : MonoBehaviour
{

    public ZomboAbstract zomboStats;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(zomboStats.damage);
        }
    }
}
