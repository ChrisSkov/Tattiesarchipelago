using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class RangedWeapon : ScriptableObject
{
    public abstract void SpawnMeIn();
    public abstract void AnimEvent();

}
