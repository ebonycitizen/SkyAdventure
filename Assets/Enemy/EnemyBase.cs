using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private int maxHP;

    private int hp;
    private int bulletLimit;

    public void UpdateBulletLimit()
    {
        bulletLimit--;

        if (bulletLimit == 0)
            GetComponent<Collider>().enabled = false;
    }

    public void UpdateHp()
    {
        hp--;
        if (hp <= 0)
            DeathEffect(gameObject);
    }

    protected virtual void Start()
    {
        hp = maxHP;
        bulletLimit = maxHP;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
                DeathEffect(gameObject);
        }
    }
    protected virtual void DeathEffect(GameObject obj)
    {
        Destroy(obj);
    }
}
