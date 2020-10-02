using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public MeleeScriptObj meleeWeapon = null;
    public MeleeScriptObj defaultMeleeWeapon;

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
        HandleWeaponBehavior();

        PickUpWeapon();
        if (meleeWeapon.isRightHanded)
        {
            stats.activeHand = rightHand;
        }
        else
        {
            stats.activeHand = leftHand;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            meleeWeapon.DropWeapon(stats.activeHand);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            meleeWeapon.triggerAttack(anim, "attack");
        }

    }

    private void HandleWeaponBehavior()
    {
        if (meleeWeapon == null)
        {
            stats.currentWeapon = defaultMeleeWeapon;
            stats.activeHand = leftHand;
        }
        meleeWeapon = stats.currentWeapon;
    }

    private void PickUpWeapon()
    {
        if (meleeWeapon.pickUp == true)
        {
            if (meleeWeapon.isRightHanded)
            {
                stats.activeHand = rightHand;
            }
            else
            {
                stats.activeHand = leftHand;
            }
            meleeWeapon.OnPickUp(stats.activeHand);
            meleeWeapon.pickUp = false;
        }
    }

    void AnimEvent()
    {
        meleeWeapon.leftClickAttack(stats.activeHand, gameObject.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(stats.activeHand.position, stats.currentWeapon.range);
    }
}
