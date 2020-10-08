using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMe : MonoBehaviour
{
    public WeaponAbstract thisWeapon;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, thisWeapon.range);
    }
}
