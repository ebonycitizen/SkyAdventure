using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCage2D : EnemyBase2D
{
    [SerializeField]
    private GameObject[] people;

    // Start is called before the first frame update
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
        //release chicken, check null

        foreach (GameObject p in people)
            p.layer = LayerMask.NameToLayer("People");

        Destroy(gameObject);
    }
}
