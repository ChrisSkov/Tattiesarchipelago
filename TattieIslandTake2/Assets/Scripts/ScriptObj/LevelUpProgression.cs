using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelUpProgression : ScriptableObject
{
    public int xpToLevel;
    public int currentLevel;
    public int currentXP;
    public int xpGrowth;
    public int attributePoints;

    public GameObject levelUpEffect;
    public AudioClip[] levelUpAudio;
    public int GetXpToLevel()
    {

        return xpToLevel = xpGrowth + xpGrowth;
    }


    public void ResetToBaseValues()
    {
        xpToLevel = 0;
        currentLevel = 1;
        currentXP = 0;
        xpGrowth = 2;
        attributePoints = 0;
    }
    public void LevelUp(Animator anim, Transform vfxSpawnPos, AudioSource source)
    {
        if (currentXP >= xpToLevel)
        {

            xpGrowth *= 2;
            if (currentLevel >= 4)
            {
                xpGrowth += currentLevel;
            }
            currentXP = 0;
            attributePoints += 1;
            currentLevel++;
            anim.SetTrigger("levelUp");
            Instantiate(levelUpEffect, vfxSpawnPos.position, vfxSpawnPos.rotation);
            AudioClip clipToPlay = levelUpAudio[Random.Range(0,levelUpAudio.Length)];
            source.PlayOneShot(clipToPlay);

        }
    }


}
