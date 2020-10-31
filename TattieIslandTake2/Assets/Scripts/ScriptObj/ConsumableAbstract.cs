using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ConsumableAbstract : ScriptableObject
{
    public float[] statGainAmount;
    public Texture2D icon;
    public GameObject prefab;
    public AudioClip[] consumeSounds;
    public Player player;
    public abstract void ConsumeItem(AudioSource source);
    public abstract void PickUpItem();
}
