using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public Transform sheathedWeaponHolder;
    public WeaponAbstract weaponInHand = null;
    public WeaponAbstract sheathedWeapon;
    public WeaponAbstract defaultWeapon;
    Vector3 mouseWorldPositon = Vector3.zero;

    Animator anim;
    public PlayerStats stats;
    public float force = 0f;
    AudioSource source;
    public float timer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Physics.IgnoreLayerCollision(10, 12);
        defaultWeapon.OnPickUp(rightHand);

    }

    // Update is called once per frame
    void Update()
    {
        if (stats.canAttack == false)
            return;
        DefaultWeaponBehavior();
        PickUpWeapon();
        HandManagement();
        DropWeapon();
        DetermineWeaponType();
        StandardWeaponAttack();
        ThrowWeaponAttack();
        if (Input.GetKeyDown(KeyCode.R))
        {

            stats.sheathedWeapon = stats.currentWeapon;
            stats.sheathedWeapon.SheathWeapon(sheathedWeaponHolder);
            stats.currentWeapon = sheathedWeapon;
            sheathedWeapon = stats.sheathedWeapon;
            if (stats.currentWeapon.isRightHanded)
            {

                stats.currentWeapon.UnSheathWeapon(rightHand);
            }
            else
            {
                stats.currentWeapon.UnSheathWeapon(leftHand);

            }
        }
        timer += Time.deltaTime;

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

                if (Input.GetKeyDown(KeyCode.E) && stats.closeToPickUp == true)
                {
                    newWeapon.pickUp = true;
                    weaponInHand = newWeapon;
                    anim.runtimeAnimatorController = weaponInHand.animOverride;

                    if (sheathedWeapon == defaultWeapon)
                    {
                        sheathedWeapon = stats.currentWeapon;
                        stats.sheathedWeapon = sheathedWeapon;
                        stats.sheathedWeapon.SheathWeapon(sheathedWeaponHolder);
                    }
                    else{
                        sheathedWeapon.DropWeapon(stats.activeHand);
                        sheathedWeapon = defaultWeapon;
                    }





                    Destroy(weaponToPickUp);
                    stats.closeToPickUp = false;
                }
                else
                {
                    newWeapon.pickUp = false;
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


        if (weaponInHand.isRightHanded)
        {
            stats.activeHand = rightHand;
        }
        else
        {
            stats.activeHand = leftHand;
        }
        if (weaponInHand.pickUp == true)
        {
            weaponInHand.OnPickUp(stats.activeHand);
        }
        weaponInHand.pickUp = false;

    }

    private void DropWeapon()
    {
        if (weaponInHand == null)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponInHand.DropWeapon(stats.activeHand);
        }
        anim.runtimeAnimatorController = weaponInHand.animOverride;
    }

    private void DetermineWeaponType()
    {
        if (weaponInHand == null)
            return;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && !stats.hasThrowable && timer >= weaponInHand.timeBetweenAttacks)
        {
            weaponInHand.triggerAttack(anim, "attack");
            timer = 0f;
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
            weaponInHand.attack(transform.GetChild(0).transform, force, source);
            force = 0f;
        }
        else
        {
            weaponInHand.leftClickAttack(stats.activeHand, gameObject.transform, source);
        }
    }

    void CanAttack()
    {
        anim.SetBool("canAttack", true);
    }

    void CannotAttack()
    {
        anim.SetBool("canAttack", false);

    }

}
