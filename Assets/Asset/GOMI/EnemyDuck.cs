using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDuck : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotio;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int maxHP;

    private int hp;

    private void Awake()
    {
        hp = maxHP;
    }


    private void Update()
    {
        if (hp <= 0)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        var diff = target.position - transform.position;
        var targetRot = Quaternion.LookRotation(diff);

        //var q = targetRot * Quaternion.Inverse(transform.rotation);
        //if (q.w < 0f)
        //{
        //    q.x = -q.x;
        //    q.y = -q.y;
        //    q.z = -q.z;
        //    q.w = -q.w;
        //}
        //var torque = new Vector3(q.x, q.y, q.z) * rotio;
        //GetComponent<Rigidbody>().AddTorque(torque);

        //GetComponent<Rigidbody>().velocity = transform.forward * speed;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotio);
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            hp--;
    }
}
