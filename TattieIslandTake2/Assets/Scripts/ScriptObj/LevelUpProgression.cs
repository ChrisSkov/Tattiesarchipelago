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

    public int GetXpToLevel()
    {

        return xpToLevel = xpGrowth + xpGrowth;
    }

    public int LevelUp(GameObject levelUpCanvas)
    {
        if (currentXP >= xpToLevel)
        {
            if (currentLevel >= 4)
            {
                xpGrowth *= 2;
            }
            xpGrowth *= 2;
            currentXP = 0;
            levelUpCanvas.SetActive(true);
            attributePoints += 1;
            return currentLevel += 1;

        }
        return currentLevel;
    }


}
