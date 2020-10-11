using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
    public PlayerStats stats;
    public WeaponObj weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stats.hasPickUpItem = true;
            other.gameObject.GetComponent<Animator>().runtimeAnimatorController = weapon.animOverrideControl;
            other.gameObject.GetComponent<Attack>().currentWeapon = weapon;
            Transform clonePos = other.gameObject.GetComponent<Attack>().weapons[0].GetComponent<Transform>();
            var clone = Instantiate(weapon.wepHoldObject, clonePos.position, clonePos.rotation);
            clone.transform.SetParent(clonePos);

            Destroy(gameObject, 0.3f);
        }
    }
}
