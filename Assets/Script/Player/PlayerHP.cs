using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private float invincibilitySec;

    public delegate void DamageHandler();
    public DamageHandler OnDamage;

    private int currentHP;

    private MeshRenderer renderer;
    private bool canReceiveDamage;

    // Start is called before the first frame update
    void Start()
    {
        renderer = transform.parent.GetComponentInChildren<MeshRenderer>();
        canReceiveDamage = true;

        currentHP = maxHP;
        OnDamage += (() => DamageEffect());
        OnDamage += (() => StartCoroutine("Invincibility"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentHP < 0 || !canReceiveDamage)
            return;

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            OnDamage();
        }
    }

    private void DamageEffect()
    {
        renderer.material.color = Color.red;
        renderer.material.DOColor(Color.white, 0.7f);
        
        //currentHP -= 1;//get enemy attack
    }

    private IEnumerator Invincibility()
    {
        canReceiveDamage = false;
        yield return new WaitForSeconds(invincibilitySec);
        canReceiveDamage = true;
    }
}
