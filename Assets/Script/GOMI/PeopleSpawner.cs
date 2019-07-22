using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField]
    private float peopleAngle;
    [SerializeField]
    private GameObject peoplePrefab;
    [SerializeField]
    private int peopleNum;

    [SerializeField]
    private Vector3 rightUp;
    [SerializeField]
    private Vector3 leftDown;

    private Vector3 self;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(Vector3 self)
    {
        this.self = self;
    }

    private IEnumerator Throw()
    {
        Vector3 target = CalRandomVec(rightUp, leftDown);
        int n = 0;
        while (n < peopleNum)
        {
            ThrowObj(peoplePrefab, target, peopleAngle);
            n++;
            yield return null;
        }
        gameObject.SetActive(false);
    }

    private void ThrowObj(GameObject prefab, Vector3 targetPos, float throwAngle)
    {
        GameObject obj = Instantiate(prefab, self, Quaternion.identity);
        Vector3 velocity = CalculateVelocity(self, targetPos, throwAngle);

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
