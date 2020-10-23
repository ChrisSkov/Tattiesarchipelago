using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WaveSet", menuName = "Waves/WaveSet", order = 0)]
public class WaveSet : ScriptableObject
{
    public Wave[] waves;
}
