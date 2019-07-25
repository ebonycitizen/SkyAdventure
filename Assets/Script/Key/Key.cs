using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
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

        if (other.gameObject.tag == "Collect")
        {
            target = other.transform;
            StartCoroutine("MoveToTarget");
        }
    }

    private IEnumerator MoveToTarget()
    {
        GetComponent<Collider>().enabled = false;

        transform.DOScale(1.5f, 1.5f);
        while(Vector3.Distance(target.position, transform.position) > stopDistance)
        {
            Vector3 velocity = (target.position - transform.position).normalized * speed * Time.deltaTime;
            transform.position += velocity;
            
            yield return null;
        }
        transform.parent = target;

        FindObjectOfType<ClearPoint>().OnCollectKey();

        yield return null;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void MoveToClearPoint(Transform target)
    {
        StartCoroutine("MoveToClear", target);
    }

    private IEnumerator MoveToClear(Transform target)
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        transform.parent = target;
        transform.DOScale(10f, 0.5f);

        float range = 5;
        float x = Random.Range(target.position.x - range, target.position.x + range);
        float y = Random.Range(target.position.y - range, target.position.y + range);
        float z = Random.Range(target.position.z - range, target.position.z + range);

        Vector3 targetPos = new Vector3(x, y, z);

        while (Vector3.Distance(targetPos, transform.position) > stopDistance)
        {
            Vector3 velocity = (targetPos - transform.position).normalized * speed * 2 * Time.deltaTime;
            transform.position += velocity;

            yield return null;
        }
        
    }
}
