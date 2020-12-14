using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCount : MonoBehaviour
{
    public Player player;
    public Slider xpSlider;
    public GameObject availablePointIndicator;


    // Start is called before the first frame update
    void Start()
    {
       // player.resources.chickens.resourceCount = GameObject.FindGameObjectsWithTag("chicken").Length;
    }

    // Update is called once per frame
    void Update()
    {
        xpSlider.value = player.progression.currentXP;
        xpSlider.maxValue = player.progression.xpToLevel;


        if (player.progression.attributePoints > 0)
        {
            availablePointIndicator.SetActive(true);
        }
        else
        {
            availablePointIndicator.SetActive(false);
        }
    }

    public void OpenMenu(GameObject menu)
    {
        if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else if (menu.activeSelf == false)
        {
            menu.SetActive(true);

        }
    }
}
