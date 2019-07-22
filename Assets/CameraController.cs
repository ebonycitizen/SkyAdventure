using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector2 moveLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3
            (Mathf.Clamp(target.position.x, -moveLimit.x, moveLimit.x),
            Mathf.Clamp(target.position.y, -moveLimit.y, moveLimit.y), transform.position.z);
    }
}
