using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HPBottle", menuName = "Items/Consumables/HPBottle", order = 0)]
public class HPBottleScriptObj : ConsumableAbstract
{
    public override void ConsumeItem(AudioSource source)
    {
        player.stats.currentHealth.statValue += statGainAmount[0];
        source.PlayOneShot(consumeSounds[Random.Range(0,consumeSounds.Length)]);
        player.resources.healthPotCount --;

    }

    public override void PickUpItem()
    {
        throw new System.NotImplementedException();
    }
}
