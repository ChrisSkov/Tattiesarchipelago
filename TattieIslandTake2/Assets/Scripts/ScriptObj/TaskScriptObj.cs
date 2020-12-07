using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TaskScriptObj : TaskAbstract
{
    GameObject toolClone;

    bool toolCloneIsLive = false;

    bool hasSpawnedLoot = false;

    public StatScriptObj treesFelled;
    public override void OnTaskBegin(Animator anim, Transform handAim)
    {
        if (animOverride != null)
        {
            anim.runtimeAnimatorController = animOverride;
        }
        if (toolCloneIsLive == false)
        {
            toolClone = Instantiate(toolPrefab, handAim.position, handAim.rotation);
            toolClone.transform.SetParent(handAim);
            toolCloneIsLive = true;
        }
        hasSpawnedLoot = false;

        anim.SetTrigger("task");

    }

    public override void OnTaskComplete(Animator anim)
    {
        anim.SetTrigger("taskComplete");
        if (!hasSpawnedLoot)
        {
            Instantiate(lootPrefab, anim.gameObject.transform.position, anim.gameObject.transform.rotation);
            hasSpawnedLoot = true;
        }
        treesFelled.statValue++;
        Destroy(anim.gameObject, 0.8f);
    }

    public override void TaskAnimEvent(GameObject taskObject, int amount, Animator anim)
    {
        anim.SetTrigger("react");
        taskObject.GetComponent<TaskBehavior>().currentHealth -= amount;
        Destroy(toolClone, 1f);
        toolCloneIsLive = false;
    }
}
