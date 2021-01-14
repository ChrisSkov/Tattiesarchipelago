using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskAbstract : ScriptableObject
{
    public Player player;
    public int maxHealth;
    public float distanceToStart;
    public AnimatorOverrideController animOverride;

    public GameObject lootPrefab;
    public GameObject toolPrefab;

    public int lootAmount;
    public int minLootAmount;
    public int maxLootAmount;

    public abstract void OnTaskComplete(Animator anim, UpdateGraph graph);
    public abstract void OnTaskBegin(Animator anim, Transform handAim);

    public abstract void TaskAnimEvent(GameObject taskObject, int amount, Animator anim);

    public abstract void SetWeaponToActive(Transform handAim);

}
