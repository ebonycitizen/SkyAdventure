using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateKeyUI : MonoBehaviour
{
    [SerializeField]
    private Text current;
    [SerializeField]
    private Text max;
    [SerializeField]
    private ClearPoint clearPoint;

    // Start is called before the first frame update
    void Start()
    {
        max.text = clearPoint.MaxKeyNum.ToString();
        
        clearPoint.OnCollectKey += (() => current.text = clearPoint.KeyNum.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
