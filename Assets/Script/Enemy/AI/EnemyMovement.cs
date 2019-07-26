using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotationDamp = 2f;
    [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField]
    private float rayCastOffest = 2.5f;
    [SerializeField]
    private float detectionDis = 15f;
    [SerializeField]
    private float rotateAngle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PathFinding();
    }

    private void Turn()
    {
        Vector3 diff = target.position - transform.position;
        Vector3 up = transform.TransformVector(transform.up);
        Quaternion rot = Quaternion.LookRotation(diff, up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationDamp * Time.deltaTime);
    }

    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffest = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffest;
        Vector3 right = transform.position + transform.right * rayCastOffest;
        Vector3 up = transform.position + transform.up * rayCastOffest;
        Vector3 down = transform.position - transform.up * rayCastOffest;

        Debug.DrawRay(left, transform.forward * detectionDis, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDis, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDis, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDis, Color.cyan);

        if(Physics.Raycast(left,transform.forward,out hit,detectionDis))
            raycastOffest += Vector3.right;
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDis))
            raycastOffest -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectionDis))
            raycastOffest -= Vector3.up;
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDis))
            raycastOffest += Vector3.up;

        if (raycastOffest != Vector3.zero)
            transform.Rotate(raycastOffest * rotateAngle * Time.deltaTime);
        else
            Turn();
    }
}
