using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResource : MonoBehaviour
{
    public ResourceScriptObj myResource;

    Image myImage;

    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        myText = GetComponentInChildren<Text>();
        myText.text = "x " + myResource.resourceCount;
        myImage.sprite = myResource.myIcon;
        if (myResource.resourceName == "Chickens")
        {
            myResource.resourceCount = GameObject.FindGameObjectsWithTag("chicken").Length;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (myResource.updateMe)
        {
            UpdateDisplay();
            
        }
        else
        {
            return;
        }
    }

    public void UpdateDisplay()
    {
        if (myResource.resourceName == "Chickens")
        {
            myResource.resourceCount = GameObject.FindGameObjectsWithTag("chicken").Length;
        }
        myText.text = "x " + myResource.resourceCount;
        myResource.updateMe = false;

    }
}
