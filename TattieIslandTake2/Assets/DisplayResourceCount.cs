using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCount : MonoBehaviour
{
    public Player player;
    public Text potatoCountText;
    public Text chickenCountText;
    public Text ammoCountText;
    // Start is called before the first frame update
    void Start()
    {
        player.resources.chickenCount = GameObject.FindGameObjectsWithTag("chicken").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: refactor to only update on value change
        potatoCountText.text = string.Format(" X " + player.resources.moneyCount);
        chickenCountText.text = string.Format(" X " + player.resources.chickenCount);
        ammoCountText.text = string.Format(" X " + player.resources.ammoCount);
    }
}
