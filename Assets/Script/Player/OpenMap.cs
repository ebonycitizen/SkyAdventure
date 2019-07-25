using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    [SerializeField]
    private Grab grab;

    private GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        map = transform.GetChild(0).gameObject;
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.HasGrab() && !map.activeSelf)
            map.SetActive(true);
        if (grab.HasRelease() && map.activeSelf)
            map.SetActive(false);
    }
}
