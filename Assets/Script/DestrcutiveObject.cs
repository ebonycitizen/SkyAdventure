using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrcutiveObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem deadEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Excute()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        deadEffect.Play();

        yield return new WaitWhile(() => deadEffect.isPlaying == true);

        Destroy(gameObject);
    }
}
