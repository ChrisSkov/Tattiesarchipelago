using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentWeapon : MonoBehaviour
{
    public RawImage currentWeaponImage;
    public RawImage sheathedWeaponImage;
    public Player player;
    public GameObject ammoObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentWeaponImage.texture = player.currentWeapon.myIcon;
        sheathedWeaponImage.texture = player.sheathedWeapon.myIcon;
        if (player.currentWeapon.hasAmmo && !ammoObject.activeSelf)
        {
            ammoObject.SetActive(true);
        }
        else if (!player.currentWeapon.hasAmmo)
        {
            ammoObject.SetActive(false);

        }
    }
}
