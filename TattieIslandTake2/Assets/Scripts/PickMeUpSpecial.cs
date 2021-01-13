using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUpSpecial : MonoBehaviour
{
    public Player player;
    public SpecialWeapon mySpecialWeapon;
    public Transform playerTransform;
    public ShowInfoOnHover hover;
    private void Start()
    {
        hover = GetComponent<ShowInfoOnHover>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) <= mySpecialWeapon.pickUpDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && hover.isHover)
            {
                mySpecialWeapon.weaponCount += 1;
                Destroy(gameObject);
            }
        }
    }

}
