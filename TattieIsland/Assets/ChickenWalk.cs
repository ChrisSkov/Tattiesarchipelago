using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChickenWalk : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    AIPath path;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        path = animator.gameObject.GetComponent<AIPath>();
        path.destination = animator.gameObject.transform.TransformDirection(Vector3.forward * 100);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // path = animator.gameObject.GetComponent<AIPath>();
        if (path.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else if (path.velocity.magnitude <= 0.1)
        {
            animator.SetBool("isWalking", false);
        }
        //  float xVelocity = path.velocity.x;
        float yVelocity = path.velocity.z;
        animator.SetFloat("forwardSpeed", yVelocity);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
