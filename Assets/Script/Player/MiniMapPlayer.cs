using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hand.position;
        transform.rotation = Quaternion.Euler(0, hand.eulerAngles.y, 0) * Quaternion.Euler(0,90,0);
    }
}
