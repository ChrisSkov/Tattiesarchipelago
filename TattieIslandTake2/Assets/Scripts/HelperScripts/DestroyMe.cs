using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    [SerializeField] float destroyTimeMin = 2f;
    [SerializeField] float destroyTimeMax = 15f;
    [SerializeField] bool randomDestroyTime = false;

    // Start is called before the first frame update
    void Start()
    {
        if (randomDestroyTime == true)
        {

            Destroy(gameObject, Random.Range(destroyTimeMin, destroyTimeMax));
        }
        else
        {
            Destroy(gameObject, destroyTime);
        }

    }
}
