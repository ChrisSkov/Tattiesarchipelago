using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public MeleeScriptObj weapon;
    Animator anim;
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = stats.currentWeapon;
        if(weapon.pickUp == true)
        {
            weapon.OnPickUp(rightHand);
            weapon.pickUp = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.triggerAttack(anim,"attack");
        }
    }

    void AnimEvent()
    {
        weapon.leftClickAttack(leftHand);
    }
}
