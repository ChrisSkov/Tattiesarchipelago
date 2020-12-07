using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformTask : MonoBehaviour
{
    public GameObject currentTaskObject;
    public Transform handAimRight;
    public Transform handAimLeft;


    public void TaskAnimEvent()
    {
        print("here");
        currentTaskObject.GetComponent<TaskBehavior>().task.TaskAnimEvent(currentTaskObject, 10, currentTaskObject.GetComponent<Animator>());
    }
}
