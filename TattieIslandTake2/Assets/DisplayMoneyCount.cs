using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMoneyCount : MonoBehaviour
{
    public Text text;
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text .text = string.Format( " X " + stats.moneyCount );
    }
}
