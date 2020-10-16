using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseScreen = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !gameIsPaused)
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            pauseScreen.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.X) && gameIsPaused)
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            pauseScreen.SetActive(false);
        }
    }
}
