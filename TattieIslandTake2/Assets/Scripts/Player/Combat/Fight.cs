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
    public Player player;
    public float force = 0f;
    AudioSource source;
    public float timer = Mathf.Infinity;
    public float specialWepTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Physics.IgnoreLayerCollision(10, 12);
        defaultWeapon.OnPickUp(rightHand);
        player.currentlySelectedBuilding = null;
        player.sheathedWeapon = defaultWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canAttack == false || player.currentlySelectedBuilding != null || player.currentTaskObj != null || player.carryChicken)
            return;

        DefaultWeaponBehavior();
       // PickUpWeapon();
        HandManagement();
        DropWeapon();
        DetermineWeaponType();
        StandardWeaponAttack();
        ThrowWeaponAttack();
        RightClickAttack();
        if (Input.GetKeyDown(KeyCode.R))
        {

            player.sheathedWeapon = player.currentWeapon;
            player.sheathedWeapon.SheathWeapon(sheathedWeaponHolder);
            player.currentWeapon = sheathedWeapon;
            sheathedWeapon = player.sheathedWeapon;
            if (player.currentWeapon.isRightHanded)
            {

                player.currentWeapon.UnSheathWeapon(rightHand);
            }
            else
            {
                player.currentWeapon.UnSheathWeapon(leftHand);

            }
        }
        timer += Time.deltaTime;
        specialWepTimer += Time.deltaTime;

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
                
                GameObject weaponToPickUp = hit.collider.gameObject;
                WeaponAbstract newWeapon = weaponToPickUp.GetComponent<PickMeUp>().thisWeapon;

                if (Input.GetKeyDown(KeyCode.E) /*&& player.closeToPickUp == true*/)
                {
                    newWeapon.pickUp = true;
                    if (weaponInHand != defaultWeapon && sheathedWeapon != defaultWeapon)
                    {
                        weaponInHand.DropWeapon(player.activeHand);
                    }
                    weaponInHand = newWeapon;
                    anim.runtimeAnimatorController = weaponInHand.animOverride;

                    if (sheathedWeapon == defaultWeapon)
                    {
                        sheathedWeapon = player.currentWeapon;
                        player.sheathedWeapon = sheathedWeapon;
                        player.sheathedWeapon.SheathWeapon(sheathedWeaponHolder);
                    }
                    Destroy(weaponToPickUp);
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
            player.currentWeapon = defaultWeapon;
            player.activeHand = leftHand;

        }
        weaponInHand = player.currentWeapon;
    }

    private void HandManagement()
    {
        if (weaponInHand == null)
            return;


        if (weaponInHand.isRightHanded)
        {
            player.activeHand = rightHand;
        }
        else
        {
            player.activeHand = leftHand;
        }
        if (weaponInHand.pickUp == true)
        {
            weaponInHand.OnPickUp(player.activeHand);
        }
        weaponInHand.pickUp = false;

    }

    private void DropWeapon()
    {
        if (weaponInHand == null)
            return;
        if (Input.GetKeyDown(KeyCode.Q) && anim.GetBool("canAttack"))
        {
            weaponInHand.DropWeapon(player.activeHand);
        }
        anim.runtimeAnimatorController = weaponInHand.animOverride;
    }

    private void DetermineWeaponType()
    {
        if (weaponInHand == null)
            return;
        if (weaponInHand.isThrowWeapon)
        {
            player.hasThrowable = true;
        }
        else
        {
            player.hasThrowable = false;
        }
    }

    private void StandardWeaponAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !player.hasThrowable && timer >= weaponInHand.timeBetweenAttacks)
        {
            weaponInHand.TriggerAttack(anim, "attack");
            timer = 0f;
        }
    }

    void RightClickAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !player.hasThrowable && timer >= weaponInHand.timeBetweenAttacks)
        {
            weaponInHand.TriggerAttack(anim, "rightClick");
            timer = 0f;
        }
    }

    private void ThrowWeaponAttack()
    {
        if (Input.GetKey(KeyCode.G) && player.selectedSpecialWeapon.weaponCount >= 1 && specialWepTimer >= player.selectedSpecialWeapon.timeBetweenUses)
        {
            force += Time.deltaTime * 12f;
        }
        else if (Input.GetKeyUp(KeyCode.G) && player.selectedSpecialWeapon.weaponCount >= 1 && specialWepTimer >= player.selectedSpecialWeapon.timeBetweenUses)
        {
            player.selectedSpecialWeapon.TriggerWeaponAnimation(anim, "specialWeapon");
            specialWepTimer = 0f;

        }
    }

    void AnimEvent()
    {
        weaponInHand.LeftClickAttack(player.activeHand, gameObject.transform, source);
    }

    void SpecialWeaponAnimEvent()
    {
        player.selectedSpecialWeapon.SpecialWeaponAnimEvent(source, transform.GetChild(0).transform, force);
        force = 0;
    }

    void AnimEventRightClick()
    {
        weaponInHand.RightClickAttack(player.activeHand, gameObject.transform, source);
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
