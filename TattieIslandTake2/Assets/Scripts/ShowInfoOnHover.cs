using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoOnHover : MonoBehaviour
{
    public Player player;
    public bool useCondition = false;
    public bool isHover = false;
    public GameObject textObject;


    private void OnMouseEnter()
    {
        if (useCondition)
        {
            if (player.carryChicken)
            {

                isHover = true;
                textObject.SetActive(true);
            }
        }
        else
        {
            isHover = true;
            textObject.SetActive(true);

        }
    }
    private void OnMouseExit()
    {
        isHover = false;
        textObject.SetActive(false);
    }
}
