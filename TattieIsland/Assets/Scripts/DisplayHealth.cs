using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Slider slider;
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = stats.currentHp;
    }
}
