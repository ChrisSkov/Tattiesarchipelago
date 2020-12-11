using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMeSpecial : MonoBehaviour
{
    public SpecialWeapon thisWeapon = null;
    public bool useWeapon = true;
    public float radius = 1f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (useWeapon == true)
        {
            Gizmos.DrawWireSphere(transform.position, thisWeapon.range);
        }
        else
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
