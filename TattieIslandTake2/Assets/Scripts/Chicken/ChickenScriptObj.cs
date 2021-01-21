﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ChickenScriptObj : ScriptableObject
{
    [Header("Health")]
    public float maxHp;
    public float hpRegen;
    public float hpRegenTime;
    
    [Header("Locomotion")]
    public float runSpeed;
    public float walkSpeed;
    [Header("Bravery")]
    public float fearOfEnemies;
    public float fleeFromEnemyRange;
    [Header("Misc")]
    public ResourceScriptObj chickenResource;
    public GameObject eggPrefab;
    public float foodSearchThreshold;
    public float layEggTime;
    public float pickUpRange;
    public string[] chickenNames;

}
