using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    GameObject activeMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();

        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMenu(GameObject menu)
    {
        if (activeMenu != null)
        {
            activeMenu.SetActive(false);
        }
        menu.SetActive(true);
        activeMenu = menu;
    }

    public void CloseMenu()
    {
        activeMenu.SetActive(false);
        activeMenu = null;
    }

}
