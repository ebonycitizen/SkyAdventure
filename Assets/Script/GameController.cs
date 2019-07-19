using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        DOTween.SetTweensCapacity(1000, 200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
