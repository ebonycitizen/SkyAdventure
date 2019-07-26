using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Stone : EnemyBase
{
    [SerializeField]
    private ParticleSystem deadEffect;

    private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            transform.localScale *= 0.98f;
            renderer.material.DOBlendableColor(Color.white, 0f);
            renderer.material.DOColor(Color.red, 0.1f);
        }
    }

    protected override void DeathEffect(GameObject obj)
    {
        deadEffect.Play();
        renderer.enabled = false;
        GetComponent<Collider>().enabled = false;

        Destroy(obj, deadEffect.main.duration);
    }
}
