using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformTask : MonoBehaviour
{
    public GameObject currentTaskObject;

    public Transform handAimRight;
    public Transform handAimLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TaskAnimEvent()
    {
       currentTaskObject.GetComponent<TaskBehavior>().task.TaskAnimEvent(currentTaskObject, 10);
    }
}
