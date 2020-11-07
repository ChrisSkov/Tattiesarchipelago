using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDeathStats : MonoBehaviour
{
    public StatScriptObj myStat;
    Text myStatText;
    // Start is called before the first frame update
    void Start()
    {
       // myStat.statValue = myStat.newValue;
        myStatText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myStatText.text = "" + myStat.statValue;

    }
}
