using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class UpdateGraph : MonoBehaviour
{
    public AstarPath path;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            path.Scan();
        }
    }
}
