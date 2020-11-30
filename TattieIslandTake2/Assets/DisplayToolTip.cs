using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToolTip : MonoBehaviour
{

    Text myText;
    KeyCode myKey;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToolTipDisplay()
    {
        myText.text = "(" + myKey + ")";
    }

    public void HideToolTip()
    {
        myText.text = null;
    }

    public void SetKeyCode(KeyCode key)
    {
        myKey = key;
    }
}
