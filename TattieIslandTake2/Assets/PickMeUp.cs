using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
    public PlayerStats stats;


    public MeleeScriptObj thisWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // other.gameObject.GetComponent<Fight>().weapon = thisWeapon;
            stats.currentWeapon = thisWeapon;
            thisWeapon.pickUp = true;
            Destroy(gameObject);
        }
    }
}
