using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DebugPlayerMove : MonoBehaviour
{

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float moveSpeed = 2.0f;

    [SerializeField]
    private float moveAngleX = 20.0f;

    [SerializeField]
    private SteamVR_Action_Boolean button;

    [SerializeField]
    private SteamVR_Action_Boolean back;

    [SerializeField]
    private SteamVR_Input_Sources left;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = cameraTransform.eulerAngles.x;

        //if (moveAngleX < x && x < 90.0f)
        if (button.GetState(left))
            MoveFoward();
        if (back.GetState(left))
            MoveBack();
    }

    private void MoveFoward()
    {
        Vector3 dir = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized * moveSpeed * Time.deltaTime;
        transform.position += dir;
    }
    private void MoveBack()
    {
        Vector3 dir = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized * moveSpeed * Time.deltaTime;
        transform.position -= dir;
    }
}
