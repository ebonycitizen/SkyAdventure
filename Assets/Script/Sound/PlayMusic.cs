using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBgmByName("MainBgm");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
