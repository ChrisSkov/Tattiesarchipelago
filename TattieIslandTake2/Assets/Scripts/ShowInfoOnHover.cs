using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoOnHover : MonoBehaviour
{

    public GameObject textObject;


    private void OnMouseEnter()
    {
        textObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        textObject.SetActive(false);
    }
}
