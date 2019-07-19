using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chicken : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float stopDistance = 0.5f;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOShakeRotation(0.2f,20))
            .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer != LayerMask.NameToLayer("People"))
            return;

        if (other.gameObject.tag == "Rescue")
        {
            target = other.transform;
            StartCoroutine("MoveToTarget");
        }
    }

    private IEnumerator MoveToTarget()
    {
        transform.DOScale(transform.lossyScale * 0.3f, 1.5f);
        while(Vector3.Distance(target.position, transform.position) > stopDistance)
        {
            Vector3 velocity = (target.position - transform.position).normalized * speed * Time.deltaTime;
            transform.position += velocity;
            
            yield return null;
        }
        transform.parent = target;

        yield return null;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
