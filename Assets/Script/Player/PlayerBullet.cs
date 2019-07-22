using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 velocity;
    private Vector3 position;
    private Vector3 direction;

    private Transform target;
    private float period;

    public void Init(Transform target)
    {
        direction = (target.position - transform.position).normalized;
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        var diff = target.transform.position - position;
        transform.rotation = Quaternion.LookRotation(diff);
        period = (target.position - transform.position).magnitude / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        var acceleration = Vector3.zero;

        var diff = target.transform.position - position;
        acceleration += (diff - velocity * period) * 2f / (period * period);

        period -= Time.deltaTime;

        if (period > 0f)
        {
            velocity += acceleration * Time.deltaTime;
        }
        else
        {
            target.GetComponent<EnemyBase>().UpdateHp();
            Destroy(gameObject);
        }

        position += velocity * Time.deltaTime;
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(diff);
    }
}
