using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrcutiveObject : GimmickBase
{
    [SerializeField]
    private ParticleSystem deadEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void DeathEffect()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(attachTarget);

        deadEffect.Play();

        yield return new WaitWhile(() => deadEffect.isPlaying == true);

        Destroy(gameObject);
        
    }
}
