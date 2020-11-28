using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public Player player;
    Animator anim;
    public AnimationClip[] levelUpAnims;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player.progression.GetXpToLevel();
        player.progression.LevelUp(anim);
        
    }
}
