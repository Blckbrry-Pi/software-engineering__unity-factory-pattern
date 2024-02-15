using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSideDirection : StateMachineBehaviour
{
    public bool DoRotation = true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float yVel = animator.GetFloat("Y Vel");
        float xInput = animator.GetFloat("X Input");

        float rawAngle = -Mathf.Atan2(yVel, 10) * Mathf.Rad2Deg;
        float angle = Mathf.Clamp(rawAngle, -40, 40);

        if (Mathf.Abs(xInput) < 0.1 || Mathf.Abs(yVel) < 0.1)
        {
            angle = 0;
        }

        if (xInput > 0)
        {
            if (DoRotation)
            {
                float lerpVal = Mathf.Clamp01(Time.deltaTime);
                Quaternion target = Quaternion.Euler(0, 0, -angle);
                Quaternion prev = animator.transform.rotation;

                Quaternion newRot = Quaternion.Lerp(target, prev, lerpVal);

                animator.transform.rotation = newRot;
            }
            animator.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            if (DoRotation)
            {
                float lerpVal = Mathf.Clamp01(0.5f * Time.deltaTime);
                Quaternion target = Quaternion.Euler(0, 0, angle);
                Quaternion prev = animator.transform.rotation;
                
                Quaternion newRot = Quaternion.Lerp(target, prev, lerpVal);

                animator.transform.rotation = newRot;
            }
            animator.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DoRotation)
        {
            animator.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        animator.transform.localScale = new Vector3(1, 1, 1);
    }

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
