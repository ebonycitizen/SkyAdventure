using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private SteamVR_Action_Boolean grip;

    [SerializeField]
    GameObject ui;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grip.stateDown)
            ui.SetActive(true);
        if (grip.stateUp)
            ui.SetActive(false);
    }
}
