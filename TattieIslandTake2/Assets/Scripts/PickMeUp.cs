using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
    public PlayerStats stats;
    public MeleeScriptObj thisWeapon;
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            stats.closeToPickUp = true;
            SwapWeapon();
        }
    }
    // private void Update()
    // {
    //     if (stats.closeToPickUp)
    //     {
    //         SwapWeapon();
    //     }
    // }
    void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            thisWeapon.pickUp = true;
            stats.currentWeapon = thisWeapon;
            Destroy(gameObject);
        }

    }
}
