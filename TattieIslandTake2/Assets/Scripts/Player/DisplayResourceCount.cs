using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCount : MonoBehaviour
{
    public Player player;
    public Text chickenCountText;
    public Text potatoCountText;
    public Text ammoCountText;
    public Text logCountText;
    public Text stoneCountText;
    public Slider xpSlider;
    public GameObject availablePointIndicator;


    // Start is called before the first frame update
    void Start()
    {
        player.resources.chickenCount = GameObject.FindGameObjectsWithTag("chicken").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: refactor to only update on value change
        chickenCountText.text = string.Format(" X " + player.resources.chickenCount);
        potatoCountText.text = string.Format(" X " + player.resources.potatoCount);
        ammoCountText.text = string.Format(" X " + player.resources.ammoCount);
        logCountText.text = string.Format(" X " + player.resources.woodCount);
        stoneCountText.text = string.Format(" X " + player.resources.stoneCount);

        // player.progression.GetXpToLevel();
        // player.progression.LevelUp();
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
