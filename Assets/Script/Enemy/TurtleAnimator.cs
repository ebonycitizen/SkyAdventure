using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class TurtleAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField]
    private BehaviorTree rotate;

    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isRotating = (bool)rotate.GetVariable("IsRotating").GetValue();



        if (agent.velocity.magnitude > 1||isRotating)
        {
            animator.SetBool("startRun", true);
        }
        else
        {
            animator.SetBool("startRun", false);
        }
    }
}
