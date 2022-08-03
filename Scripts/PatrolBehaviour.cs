using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent Ladyzombie;
    Transform Player;
    float chaserange = 20;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform waypointsObj = GameObject.FindGameObjectWithTag("Waypoints").transform;
        foreach (Transform t in waypointsObj)
            waypoints.Add(t);
        Ladyzombie = animator.GetComponent<NavMeshAgent>();
        Ladyzombie.SetDestination(waypoints[0].position);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Ladyzombie.remainingDistance <= Ladyzombie.stoppingDistance)
            Ladyzombie.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        timer += Time.deltaTime;
        if (timer > 20)
        {
            animator.SetBool("ispatroling", false);
            float distance = Vector3.Distance(animator.transform.position, Player.position);
            if(distance < chaserange)
            {
                animator.SetBool("ischasing", true); 
            }

        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ladyzombie.SetDestination(Ladyzombie.transform.position);
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
