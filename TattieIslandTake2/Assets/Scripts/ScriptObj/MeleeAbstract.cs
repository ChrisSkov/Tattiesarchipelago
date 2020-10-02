using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class MeleeAbstract : ScriptableObject
{
    public abstract void leftClickAttack(Transform pos, Transform rayCastPosition);
    public abstract void rightClickAttack(Transform pos);
    public abstract void triggerAttack(Animator anim, string trigger);
    public abstract void OnPickUp(Transform pos);
    public abstract void DropWeapon(Transform pos);
}
