using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Audio", order = 3)]
public class PlayerAudio : ScriptableObject
{
    public AudioClip walkSound;
    public AudioClip deathSound;
    public AudioClip[] takeDamageSounds;
    public AudioClip[] jumpSounds;
    public AudioClip[] attackSounds;
    public AudioClip[] taskSounds;

}
