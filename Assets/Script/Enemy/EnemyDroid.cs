using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyDroid : EnemyBase
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotio;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    [SerializeField]
    private float shotIntervalSec = 1;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPos;

    [SerializeField]
    private Transform modelTransform;

    private bool canShot;

    protected override void Start()
    {
        base.Start();
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        var diff = target.position - transform.position;
        var targetRot = Quaternion.LookRotation(diff);


        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotio);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    IEnumerator Shot()
    {
        while (true)
        {
            if (target == null)
                yield return null;

            //if (!canShot)
            //    yield return null;

            modelTransform.DOLocalRotate(new Vector3(0, 0, 360 * 4), shotIntervalSec / 2, RotateMode.FastBeyond360).SetEase(Ease.OutExpo);

            yield return new WaitForSeconds(shotIntervalSec / 4);

            GameObject bullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Init(transform.forward);

            yield return new WaitForSeconds(shotIntervalSec);

            canShot = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            canShot = true;
        }
    }
}
