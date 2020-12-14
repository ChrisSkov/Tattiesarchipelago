using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[CreateAssetMenu]
public class TaskScriptObj : TaskAbstract
{
    GameObject toolClone;

    bool toolCloneIsLive = false;

    bool hasSpawnedLoot = false;

    public StatScriptObj numberOfTasksCompleted;

    public UpdateGraph updateGraph;
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

    public override void OnTaskComplete(Animator anim, UpdateGraph graph)
    {
        anim.SetTrigger("taskComplete");
        if (!hasSpawnedLoot)
        {
            Instantiate(lootPrefab, anim.gameObject.transform.position, anim.gameObject.transform.rotation);
            hasSpawnedLoot = true;
        }
        numberOfTasksCompleted.statValue++;
        Destroy(anim.gameObject, 0.8f);
        player.currentTaskObj = null;
        graph.GraphUpdate();
    }

    public override void TaskAnimEvent(GameObject taskObject, int amount, Animator anim)
    {
        if (anim != null)
        {
            anim.SetTrigger("react");
        }
        taskObject.GetComponent<TaskBehavior>().currentHealth -= amount;
        Destroy(toolClone, 1f);
        toolCloneIsLive = false;
        player.currentTaskObj = null;
    }
}
