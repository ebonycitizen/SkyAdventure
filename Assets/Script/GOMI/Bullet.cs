using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 500f;
    [SerializeField]
    private float deadDelayTime = 2f;

    private Vector3 velocity;
    private Vector3 direction;
    private Rigidbody rigidbody;

    public void Init(Transform target)
    {
        direction = (target.position - transform.position).normalized;
    }

    public void Init(Vector3 vec)
    {
        direction = vec.normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        velocity = direction * speed * Time.fixedDeltaTime;
        rigidbody.velocity = velocity;

        Destroy(gameObject, deadDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
