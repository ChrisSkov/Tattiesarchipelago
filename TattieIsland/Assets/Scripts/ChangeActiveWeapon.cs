using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveWeapon : MonoBehaviour
{
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetBool("canChangeWeapons"))
        {
            ChangeWeapon();
        }

    }
    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stats.currentlyEquippedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stats.currentlyEquippedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stats.currentlyEquippedWeapon = 2;
        }
    }
}
