using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyItem2D : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float stopDistance = 0.1f;

    private Transform target;

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
        if (gameObject.layer != LayerMask.NameToLayer("People"))
            return;

        if (collision.gameObject.tag == "Rescue")
        {
            target = collision.transform;
            StartCoroutine("MoveToTarget");
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.layer != LayerMask.NameToLayer("People"))
            return;

        if (collision.gameObject.tag == "Rescue")
        {
            target = collision.transform;
            StartCoroutine("MoveToTarget");
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(target.position, transform.position) > stopDistance)
        {
            Vector3 velocity = (target.position - transform.position).normalized * speed * Time.deltaTime;
            transform.position += velocity;

            yield return null;
        }
        transform.parent = target;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return null;
        
    }
}
