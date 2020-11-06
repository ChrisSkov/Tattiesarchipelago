using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStatReset : MonoBehaviour
{
    public StatScriptObj[] statsToReset;
    // Start is called before the first frame update
    void Start()
    {
        foreach(StatScriptObj stat in statsToReset)
        {
            stat.ResetToBaseValue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
