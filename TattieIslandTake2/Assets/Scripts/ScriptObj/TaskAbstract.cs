using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskAbstract : ScriptableObject
{
    public int maxHealth;
    public float distanceToStart;
    public AnimatorOverrideController animOverride;

    public GameObject lootPrefab;
    public GameObject toolPrefab;

    public int lootAmount;

    public abstract void OnTaskComplete(Animator anim);
    public abstract void OnTaskBegin(Animator anim, Transform handAim);

    public abstract void TaskAnimEvent(GameObject taskObject, int amount, Animator anim);

}
