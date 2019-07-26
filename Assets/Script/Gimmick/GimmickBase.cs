using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject attachTarget;
    [SerializeField]
    private int maxHP;

    private int hp;

    protected virtual void Start()
    {
        hp = maxHP;
    }

    public virtual void Excute()
    {
        hp--;
        if (hp <= 0)
            DeathEffect();
    }

    protected virtual void DeathEffect()
    {
        Destroy(gameObject);
        Destroy(attachTarget);
    }
}
