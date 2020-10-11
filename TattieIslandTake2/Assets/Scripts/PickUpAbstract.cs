using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class PickUpAbstract : ScriptableObject
{
    public GameObject pickUpPrefab;
    public float pickUpRadius;
}
