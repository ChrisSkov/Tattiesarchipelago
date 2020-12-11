using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpecialWeapon : MonoBehaviour
{
    public Player player;

    public Image wepImage;

    public Text amountText;
    // Start is called before the first frame update
    void Start()
    {
        amountText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        wepImage.sprite = player.selectedSpecialWeapon.weaponIcon;

        amountText.text = "" + player.selectedSpecialWeapon.weaponCount;
    }

}
