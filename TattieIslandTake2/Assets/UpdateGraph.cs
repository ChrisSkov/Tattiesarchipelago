using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class UpdateGraph : MonoBehaviour
{
    public AstarPath path;
    public bool scanMe = false;
    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || scanMe)
        {
            path.Scan();
            scanMe = false;
        }
    }

    public void GraphUpdate()
    {
       scanMe = true;
    }
}
