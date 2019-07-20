using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float lineLength = 5f;
    [SerializeField]
    private Transform linePosition;
    [SerializeField]
    private float shotIntervalSec = 0.12f;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private ParticleSystem muzzleEffect;

    private LineRenderer lineRenderer;
    private RaycastHit2D hit;
    private Vector3 direction;

    private int layerMask;//for enemy
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        layerMask = 1 << 11;
    }
    void OnEnable()
    {
        StartCoroutine("StartShot");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
        Move();
    }
    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, linePosition.position);
        lineRenderer.SetPosition(1, linePosition.position + transform.up * lineLength-new Vector3(0,0,3.0f));
    }

    private void Shot(GameObject target)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
        bullet.GetComponent<Shot2D>().Init(target.transform);
        target.GetComponent<EnemyBase2D>().UpdateBulletLimit();
        muzzleEffect.Play();
    }

    private GameObject AimTarget()
    {
        hit = Physics2D.Raycast(transform.position, transform.up, lineLength, layerMask);

        if (hit.collider)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
    private IEnumerator StartShot()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            GameObject target = AimTarget();
            if (target != null)
            {
                Shot(target);
                yield return new WaitForSeconds(shotIntervalSec);
            }
            yield return null;
        }
    }

    private void Move()
    {

        float h1 = Input.GetAxis("Horizontal");
        float v1 = Input.GetAxis("Vertical");

        float h2 = Input.GetAxis("Horizontal2");
        float v2 = Input.GetAxis("Vertical2");

        Vector3 vec = new Vector3(h1, v1) * moveSpeed * Time.deltaTime;
        transform.position += vec;

        if (h2 != 0 || v2 != 0)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v2, h2) * Mathf.Rad2Deg - 90);
   }
}
