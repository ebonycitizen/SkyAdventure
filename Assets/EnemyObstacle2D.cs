using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle2D : EnemyBase2D
{
    [SerializeField]
    private GameObject effect;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void DeathEffect(GameObject obj)
    {
        base.DeathEffect(obj);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
