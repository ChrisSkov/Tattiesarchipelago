using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithItem : MonoBehaviour
{
    Animator anim;
    public RangedWepObj obj;

    public Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            obj.hand = hand;
            GetComponent<Animator>().runtimeAnimatorController = obj.animOverride;
            GetComponent<Animator>().SetTrigger("rightClick");

        }
    }
    public void AnimEvent()
    {
        var clone = Instantiate(obj.prefab, obj.hand.position, obj.hand.rotation);
        clone.AddComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 20f, ForceMode.Impulse);
    }

}
