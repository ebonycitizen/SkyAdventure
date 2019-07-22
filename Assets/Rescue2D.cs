using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue2D : MonoBehaviour
{
    [SerializeField]
    private GameObject clearShield;
    [SerializeField]
    private GameObject clearPoint;
    [SerializeField]
    private int clearCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = transform.childCount;

        if (clearShield != null && count >= clearCount)
        {
            Destroy(clearShield);
            clearPoint.layer = LayerMask.NameToLayer("ClearPoint");
        }
    }
}
