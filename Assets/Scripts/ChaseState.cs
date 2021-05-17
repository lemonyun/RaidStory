using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachineBehaviour
{
    private Transform monsterPos;
    private Transform playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        monsterPos = GameObject.FindGameObjectWithTag("Monster").transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monsterPos.position = Vector3.MoveTowards(monsterPos.position, playerPos.position, speed * Time.deltaTime);
        

        monsterPos.LookAt(playerPos);
        monsterPos.Rotate(0, -90, 0);
        if(Vector3.Distance(monsterPos.position, playerPos.position) < 2.0f)
        {
            if(!animator.GetBool("isAttack"))
                animator.SetBool("isAttack", true);
            
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
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
