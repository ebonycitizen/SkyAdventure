using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    [SerializeField]
    private Transform handLeft;
    [SerializeField]
    private Transform handRight;

    [SerializeField]
    private Transform rotateLeft;
    [SerializeField]
    private Transform rotateRight;

    private Quaternion offset;
    private Quaternion previous;
    private Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        offset = Quaternion.Euler(0, -175, 0);
        previous = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdatePosition();
        //UpdateRotation();
    }

    private void UpdatePosition()
    {
        Vector3 position = (handLeft.position + handRight.position) / 2;
        transform.position = position;
    }
    private void UpdateRotation()
    {
        Quaternion combine = Quaternion.Lerp(rotateLeft.rotation, rotateRight.rotation, 0.5f);
        Quaternion rot = combine * offset;

        float magnitude = (rot.eulerAngles - previous.eulerAngles).magnitude;
        if (magnitude > 345f && magnitude <= 360f)
            transform.Rotate(diff);
        else
            transform.rotation = rot;

        diff = transform.eulerAngles - previous.eulerAngles;
        previous = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "People")
        {
            Destroy(other.gameObject);
        }
    }
}
