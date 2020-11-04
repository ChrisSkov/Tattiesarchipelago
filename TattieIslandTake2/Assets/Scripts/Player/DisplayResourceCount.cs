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
    public GameObject levelUpCanvas;
    public Slider xpSlider;
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
        potatoCountText.text = string.Format(" X " + player.resources.moneyCount);
        ammoCountText.text = string.Format(" X " + player.resources.ammoCount);
        player.progression.GetXpToLevel();
        xpSlider.value = player.progression.currentXP;
        xpSlider.maxValue = player.progression.xpToLevel;
        player.progression.LevelUp(levelUpCanvas);
    }
}
