using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    public float maxSize = 1.2f;
    public float minSize = 0.25f;
    public float actualSize = .5f;
    // Start is called before the first frame update
    void Start()
    {
        actualSize= Random.Range(minSize,maxSize);
        transform.localScale = new Vector3(actualSize,actualSize,actualSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
