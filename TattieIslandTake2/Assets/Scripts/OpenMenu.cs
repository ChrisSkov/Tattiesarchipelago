using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuToOpen;
    public KeyCode keyToOpen;

    public GameObject uiButton;

    // Start is called before the first frame update
    void Start()
    {
        uiButton.GetComponent<DisplayToolTip>().SetKeyCode(keyToOpen);
    }

    // Update is called once per frame
    void Update()
    {
        if (uiButton.GetComponent<DisplayToolTip>().GetKeyCode() != keyToOpen)
        {
            uiButton.GetComponent<DisplayToolTip>().SetKeyCode(keyToOpen);
        }
        if (Input.GetKeyDown(keyToOpen))
        {
            if (menuToOpen.activeSelf == true)
            {
                menuToOpen.SetActive(false);
            }
            else
            {
                menuToOpen.SetActive(true);
            }
        }
    }


}
