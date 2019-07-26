using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject damageEffect;

    void Awake()
    {
        damageEffect.SetActive(false);
    }

    void Start()
    {
        FindObjectOfType<PlayerHP>().OnDamage += (() => StartCoroutine("Damage"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Damage()
    {
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageEffect.SetActive(false);
    }
}
