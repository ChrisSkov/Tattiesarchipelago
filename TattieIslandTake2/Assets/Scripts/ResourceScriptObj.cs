using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class ResourceScriptObj : ScriptableObject
{
    public string resourceName;
    public int resourceCount;
    public Sprite myIcon;
    public bool updateMe;
}
