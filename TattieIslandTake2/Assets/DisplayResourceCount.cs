using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCount : MonoBehaviour
{
    public Text potatoCountText;
    public Text chickenCountText;
    public Player stats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        potatoCountText.text = string.Format( " X " + stats.moneyCount );
    }
}
