using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "TattieIslandTake2/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
    public MeleeAbstract currentWeapon;
    public Transform activeHand;
    public bool closeToPickUp;
    public float maxMoveSpeed;
    public float currentMoveSpeed;
    public float maxHealth;
    public float currentHealth;
    public float stepSoundDelay;
    public AudioClip walkSound;

}

