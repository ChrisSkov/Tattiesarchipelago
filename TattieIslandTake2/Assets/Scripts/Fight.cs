using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public WeaponAbstract weaponInHand = null;
    public WeaponAbstract defaultWeapon;

    Vector3 mouseWorldPositon = Vector3.zero;

    Animator anim;
    public PlayerStats stats;
    public float force = 0f;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DefaultWeaponBehavior();
        PickUpWeapon();

        HandManagement();
        DropWeapon();
        DetermineWeaponType();
        StandardWeaponAttack();
        ThrowWeaponAttack();
        if (weaponInHand.isRightHanded)
        {
            stats.activeHand = rightHand;
        }
        else
        {
            stats.activeHand = leftHand;
        }



    }

    private void PickUpWeapon()
    {
        //Set up hit, ray and mask for raycast
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("WeaponPickUp");

        //execute raycast and calculate mouse position
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) <= 5f)
            {
                stats.closeToPickUp = true;
                GameObject weaponToPickUp = hit.collider.gameObject;
                WeaponAbstract newWeapon = weaponToPickUp.GetComponent<PickMeUp>().thisWeapon;

                newWeapon.pickUp = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    weaponInHand = newWeapon;
                    if (stats.currentWeapon != defaultWeapon)
                    {
                        stats.currentWeapon.DropWeapon(stats.activeHand);
                    }
                    Destroy(weaponToPickUp);
                }
            }
        }
    }

    private void DefaultWeaponBehavior()
    {
        if (weaponInHand == null)
        {
            stats.currentWeapon = defaultWeapon;
            stats.activeHand = leftHand;
        }
        weaponInHand = stats.currentWeapon;
    }

    private void HandManagement()
    {
        if (weaponInHand == null)
            return;


        if (weaponInHand.pickUp == true)
        {
            if (weaponInHand.isRightHanded)
            {
                stats.activeHand = rightHand;
            }
            else
            {
                stats.activeHand = leftHand;
            }
            weaponInHand.OnPickUp(stats.activeHand);
            weaponInHand.pickUp = false;
        }

    }

    private void DropWeapon()
    {
        if (weaponInHand == null)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponInHand.DropWeapon(stats.activeHand);
        }
    }

    private void DetermineWeaponType()
    {
        if (weaponInHand.isThrowWeapon)
        {
            stats.hasThrowable = true;
        }
        else
        {
            stats.hasThrowable = false;
        }
    }

    private void StandardWeaponAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !stats.hasThrowable)
        {
            weaponInHand.triggerAttack(anim, "attack");
        }
    }

    private void ThrowWeaponAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && stats.hasThrowable)
        {
            force += Time.deltaTime * 12f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && stats.hasThrowable)
        {
            weaponInHand.triggerAttack(anim, "attack");

        }
    }

    void AnimEvent()
    {
        if (stats.hasThrowable)
        {
            weaponInHand.attack(transform.GetChild(0).transform, force);
            force = 0f;
        }
        else
        {
            weaponInHand.leftClickAttack(stats.activeHand, gameObject.transform, GetComponent<AudioSource>());
        }
    }

}
