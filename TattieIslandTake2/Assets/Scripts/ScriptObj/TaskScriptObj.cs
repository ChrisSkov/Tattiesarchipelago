using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TaskScriptObj : TaskAbstract
{
    GameObject toolClone;
    public override void OnTaskBegin(Animator anim, Transform handAim)
    {
        if (animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        toolClone = Instantiate(toolPrefab, handAim.position, toolPrefab.transform.rotation);
        toolClone.transform.SetParent(handAim);
        //toolClone.transform.rotation = handAim.rotation;

        anim.SetTrigger("task");
        Debug.Log("eow");
    }

    public override void OnTaskComplete(Animator anim)
    {
        throw new System.NotImplementedException();
    }

    public override void TaskAnimEvent(GameObject taskObject, int amount)
    {
        taskObject.GetComponent<TaskBehavior>().currentHealth -= amount;
        Destroy(toolClone, 1.5f);
    }
}
