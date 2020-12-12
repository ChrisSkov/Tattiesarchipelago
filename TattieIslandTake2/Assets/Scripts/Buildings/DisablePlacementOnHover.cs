using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlacementOnHover : MonoBehaviour
{
    public Player player;

    public bool hoverUI = false;



    public void MouseEnterUI()
    {
        hoverUI = true;
    }

    public void MouseExitUI()
    {
        hoverUI = false;
    }
}
