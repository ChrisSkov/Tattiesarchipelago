using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelUpProgression : ScriptableObject
{
    // xp required to reach next level
    public int xpToLevel;
    // Level we are currently at
    public int currentLevel;
    // Amount of xp we currently have
    public int currentXP;
    // Current xp growth amount
    public int xpGrowth;
    // Current amount of attribute points we have
    public int attributePoints;
    // Level up VFX
    public GameObject levelUpEffect;
    // Level up audio array
    public AudioClip[] levelUpAudio;

    
    public int GetXpToLevel()
    {

        return xpToLevel = xpGrowth + xpGrowth;
    }
    public void LevelUp(Animator anim, Transform vfxSpawnPos, AudioSource source)
    {
        // Do we have enough xp to level up?
        if (currentXP >= xpToLevel)
        {
            // Increase the amount of xp require for the next level    
            xpGrowth *= 2;
            // If we're level 4 or higher increase xp growth by our current level as well
            if (currentLevel >= 4)
            {
                xpGrowth += currentLevel;
            }
            // Reset our xp amount
            currentXP = 0;
            // Gain an attributepoint
            attributePoints += 1;
            // Gain a level
            currentLevel++;
            // Play level up animation
            anim.SetTrigger("levelUp");
            // Spawn in level up effects
            Instantiate(levelUpEffect, vfxSpawnPos.position, vfxSpawnPos.rotation);
            // Choose random soundclip from our AudioClip array
            AudioClip clipToPlay = levelUpAudio[Random.Range(0, levelUpAudio.Length)];
            // Play that sound
            source.PlayOneShot(clipToPlay);

        }
    }

    public void ResetToBaseValues()
    {
        xpToLevel = 0;
        currentLevel = 1;
        currentXP = 0;
        xpGrowth = 2;
        attributePoints = 0;
    }


}
