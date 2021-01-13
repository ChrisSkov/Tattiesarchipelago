using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
    public Player stats;
    public WeaponAbstract thisWeapon;
    Transform playerTransform;
    ShowInfoOnHover hover;
    Fight fight;
    private void Start()
    {
        hover = GetComponent<ShowInfoOnHover>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        fight = playerTransform.GetComponent<Fight>();

    }
    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) <= thisWeapon.pickUpDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && hover.isHover)
            {
                if (stats.sheathedWeapon != fight.defaultWeapon)
                {
                    stats.currentWeapon.DropWeapon(stats.activeHand);
                    stats.currentWeapon = thisWeapon;
                }
                else
                {
                    stats.sheathedWeapon = stats.currentWeapon;
                    fight.sheathedWeapon = stats.sheathedWeapon;
                    stats.currentWeapon.SheathWeapon(fight.sheathedWeaponHolder);
                    stats.currentWeapon = thisWeapon;
                }
                thisWeapon.pickUp = true;
                Destroy(gameObject);
            }
        }
    }
}
