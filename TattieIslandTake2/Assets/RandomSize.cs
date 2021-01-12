using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    public float maxSize = 1.2f;
    public float minSize = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(minSize,maxSize),Random.Range(minSize,maxSize),Random.Range(minSize,maxSize));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
