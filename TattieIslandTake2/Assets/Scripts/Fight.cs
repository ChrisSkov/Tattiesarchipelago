using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public WeaponAbstract meleeWeapon = null;
    public WeaponAbstract defaultMeleeWeapon;

    Vector3 mouseWorldPositon = Vector3.zero;

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
        //Set up hit, ray and mask for raycast
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("WeaponPickUp");

        //execute raycast and calculate mouse position
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            print(hit.collider.gameObject);
        }

        PickUpWeapon();
        if (meleeWeapon.isRightHanded)
        {
            stats.activeHand = rightHand;
        }
        else
        {
            stats.activeHand = leftHand;
        }

        if (Input.GetKeyDown(KeyCode.Q) && meleeWeapon != null)
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
        if (meleeWeapon != null && meleeWeapon.pickUp == true)
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
        meleeWeapon.leftClickAttack(stats.activeHand, gameObject.transform, GetComponent<AudioSource>());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.GetChild(0).transform.position, transform.TransformDirection(Vector3.forward) * 3);
        if (stats.activeHand != null && Application.isPlaying)
        {
            Gizmos.DrawWireSphere(stats.activeHand.position, stats.currentWeapon.range);
        }
        Gizmos.DrawWireSphere(mouseWorldPositon, 1f);
    }
}
