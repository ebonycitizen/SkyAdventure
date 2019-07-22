using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearPoint2D : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform target;

    [SerializeField]
    private GameObject clearText;

    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOShakeRotation(0.2f, 20))
            .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer != LayerMask.NameToLayer("ClearPoint"))
            return;

        if (collision.gameObject.tag == "Rescue")
        {
            target = collision.transform;
            clearText.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.layer != LayerMask.NameToLayer("ClearPoint"))
            return;

        if (collision.gameObject.tag == "Rescue")
        {
            target = collision.transform;
            clearText.SetActive(true);
        }
    }

}
