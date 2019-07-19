using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPenguin : EnemyBase
{
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Transform[] targets;

    [SerializeField]
    private float shotIntervalSec = 1;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPos;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform target in targets)
        {
            if (target == null)
                return;

            var relativePos = target.position - transform.position;
            var rotation = Quaternion.LookRotation(relativePos);
            transform.rotation =
              Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

            return;
        }
    }

    IEnumerator Shot()
    {
        while (true)
        {
            foreach (Transform target in targets)
            {
                if (target == null)
                    yield return null;

                GameObject bullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().Init(target.position-transform.position);
            }
            yield return new WaitForSeconds(shotIntervalSec);
        }
    }
}
