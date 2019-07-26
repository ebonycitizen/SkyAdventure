using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BirdAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private NavMeshAgent agent;
    
    // Update is called once per frame
    void Update()
    {
        //if (agent.velocity.magnitude > 1)
        //{
        //    animator.SetBool("startRun", true);
        //}
        //else
        //{
        //    animator.SetBool("startRun", false);
        //}
    }
}
