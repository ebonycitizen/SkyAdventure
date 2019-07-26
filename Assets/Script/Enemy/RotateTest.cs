using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public Transform _target;

    void Update()
    {
        Vector3 direction = (_target.position - this.transform.position).normalized;
        this.transform.forward = direction;
        this.transform.LookAt(_target.position);
    }

}
