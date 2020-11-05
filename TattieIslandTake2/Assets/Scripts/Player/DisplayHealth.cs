using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Player player;
    //  Slider slider;

    public Image image;
    Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponentInChildren<Text>();
        // slider = GetComponentInChildren<Slider>();
        // slider.maxValue = player.stats.maxHealth;
    }

    // Update is called once per frame  
    void Update()
    {
        hpText.text = string.Format("{0}/{1}", Mathf.RoundToInt(player.stats.currentHealth.statValue), Mathf.RoundToInt(player.stats.maxHealth.statValue));
        //   slider.value = player.stats.currentHealth;
        image.fillAmount = player.stats.currentHealth.statValue / player.stats.maxHealth.statValue;
//        print(player.stats.currentHealth.statValue / player.stats.maxHealth.statValue);
    }
}
