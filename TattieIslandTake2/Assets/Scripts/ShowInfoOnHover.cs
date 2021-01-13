using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoOnHover : MonoBehaviour
{

    public bool isHover = false;
    public GameObject textObject;


    private void OnMouseEnter()
    {
        isHover = true;
        textObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        isHover = false;
        textObject.SetActive(false);
    }
}
