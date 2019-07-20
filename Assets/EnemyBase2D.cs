using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase2D : MonoBehaviour
{
    [SerializeField]
    private int maxHP;

    private int hp;
    private int bulletLimit;

    public void UpdateBulletLimit()
    {
        bulletLimit--;

        if (bulletLimit == 0)
            GetComponent<Collider2D>().enabled = false;
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
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
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
