using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformTask : MonoBehaviour
{
    public GameObject currentTaskObject;
    public Transform handAimRight;
    public Transform handAimLeft;

    //Triggers the animation event in the task script obj
    public void TaskAnimEvent()
    {
        currentTaskObject.GetComponent<TaskBehavior>().task.TaskAnimEvent(currentTaskObject, 10, currentTaskObject.GetComponent<Animator>());
    }

    //Sets the player weapon to active when the animation is complete
    public void ShowWeapon()
    {
        currentTaskObject.GetComponent<TaskBehavior>().task.SetWeaponToActive(handAimRight);
    }
}
