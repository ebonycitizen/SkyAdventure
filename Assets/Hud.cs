using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField]
    private Image hpGauge;
    [SerializeField]
    private Image starGauge;

    [SerializeField]
    private GameObject rescue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starGauge.fillAmount = (float)1/5*rescue.transform.childCount;
    }
}
