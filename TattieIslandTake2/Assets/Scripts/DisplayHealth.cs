using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public PlayerStats stats;
    Slider slider;
    Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponentInChildren<Text>();
        slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = string.Format("{0}/{1}", Mathf.RoundToInt(stats.currentHealth), Mathf.RoundToInt(stats.maxHealth));
        slider.value = stats.currentHealth;
    }
}
