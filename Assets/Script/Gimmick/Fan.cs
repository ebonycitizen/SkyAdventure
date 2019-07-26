using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fan : GimmickBase
{

    [SerializeField]
    private ParticleSystem deadEffect;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void Excute()
    {
        base.Excute();
        transform.parent.DORotate(new Vector3(0, transform.parent.eulerAngles.y - 45, 0), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);

        //StartCoroutine("RotateObject");
    }
    protected override void DeathEffect()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        Destroy(attachTarget);

        deadEffect.Play();

        yield return new WaitWhile(() => deadEffect.isPlaying == true);

        Destroy(gameObject);

    }
    private IEnumerator RotateObject()
    {
        float time=0;
        while (true)
        {
            float angle = Mathf.LerpAngle(0, 45,time );
            transform.parent.eulerAngles = new Vector3(0, transform.parent.rotation.y - angle, 0);

            if (time > 1)
                break ;

            time += Time.deltaTime;

            yield return null;
        }
        
        yield return null;
    }
}
