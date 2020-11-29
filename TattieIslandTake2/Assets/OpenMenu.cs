using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuToOpen;
    public KeyCode keyToOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToOpen))
        {
            if(menuToOpen.activeSelf == true)
            {
                menuToOpen.SetActive(false);
            }
            else{
                menuToOpen.SetActive(true);
            }
        }
    }
}
