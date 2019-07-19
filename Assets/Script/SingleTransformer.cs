using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTransformer : MonoBehaviour
{
    [SerializeField]
    private GameObject shotShip;
    [SerializeField]
    private GameObject alienShip;
    [SerializeField]
    private Grab grab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateForm();
    }

    private void UpdateForm()
    {
        if(grab.NumberOfGrabFingers() > 3 && !shotShip.activeSelf)
        {
            shotShip.SetActive(true);
            alienShip.SetActive(false);
        }
        if (grab.NumberOfGrabFingers() == 0 && shotShip.activeSelf)
        {
            shotShip.SetActive(false);
            alienShip.SetActive(true);
        }
    }
}
