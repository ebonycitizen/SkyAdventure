using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyHeli : EnemyBase
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float radius;

    [SerializeField]
    private float bombAngle;
    [SerializeField]
    private GameObject bombPrefab;

    [SerializeField]
    private Transform targetPosition;

    [SerializeField]
    private GameObject explodeEffect;
    [SerializeField]
    private GameObject peopleSpawner;

    [SerializeField]
    private GameObject fireEffect;


    private Vector3 center;
    private Vector3 prevPos;

    private bool isDeath=false;

    private void OnDisable()
    {
        //Instantiate(explodeEffect, transform.position, Quaternion.identity);

        //GameObject spawner = Instantiate(peopleSpawner, Vector3.zero, Quaternion.identity);
        //PeopleSpawner p = spawner.GetComponent<PeopleSpawner>();
        //p.SetUp(transform.position);
    }

    protected override void DeathEffect(GameObject obj)
    {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);

        GameObject spawner = Instantiate(peopleSpawner, Vector3.zero, Quaternion.identity);
        PeopleSpawner p = spawner.GetComponent<PeopleSpawner>();
        p.SetUp(transform.position);

        Instantiate(fireEffect, transform);

        isDeath = true;
        float distance = 100;

        transform.DOMove(new Vector3(transform.position.x + transform.right.x * distance, 0, transform.position.z + transform.right.z * distance), 10).OnComplete(() => DestroyObject());

        transform.DOLocalRotate(new Vector3(10, transform.rotation.y + 1200, 30), 8.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        //StartCoroutine("DeathMove");
    }

    private void DestroyObject()
    {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DeathMove()
    {
        Vector3 dir = (targetPosition.position - transform.position).normalized;
        float speed=50;

        while(true)
        {
            if (transform.position.y < 0)
                break;

            transform.position += dir * Time.deltaTime * speed;
            yield return null;
        }
        yield return null;
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        center = transform.position;
        prevPos = transform.position;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
            return;

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObj(bombPrefab, targetPosition.position, bombAngle);
        }
    }

    private void Move()
    {
        float x = Mathf.Sin(Time.time * speed) * radius + center.x;
        float z = Mathf.Cos(Time.time * speed) * radius + center.z;

        transform.position = new Vector3(x, center.y, z);

        Vector3 diff = transform.position - prevPos;
        transform.rotation = Quaternion.LookRotation(diff);
        prevPos = transform.position;
    }

    private void ThrowObj(GameObject prefab, Vector3 targetPos, float throwAngle)
    {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        Vector3 velocity = CalculateVelocity(transform.position, targetPos, throwAngle);

        float angleY = Random.Range(0, 360);
        obj.transform.eulerAngles = new Vector3(0, angleY, 0);

        Vector3 direction = Vector3.one * 3;
        Vector3 initVelocity = CalRandomVec(-direction, direction);

        Rigidbody rigid = obj.GetComponent<Rigidbody>();
        rigid.AddForce(velocity + initVelocity, ForceMode.Impulse);
    }

    private Vector3 CalculateVelocity(Vector3 self, Vector3 target, float angle)
    {
        float rad = Mathf.Deg2Rad;

        float x = Vector2.Distance(new Vector2(self.x, self.z), new Vector2(target.x, target.z));
        float y = self.y - target.y;

        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        Vector3 velocity = new Vector3(target.x - self.x, x * Mathf.Tan(rad), target.z - self.z).normalized * speed;

        return velocity;
    }

    private Vector3 CalRandomVec(Vector3 a, Vector3 b)
    {
        float x = Random.Range(a.x, b.x);
        float y = Random.Range(a.y, b.y);
        float z = Random.Range(a.z, b.z);

        return new Vector3(x, y, z);
    }
}
