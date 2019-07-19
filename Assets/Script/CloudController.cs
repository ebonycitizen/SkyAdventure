using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //private List<ParticleSystem> clouds;

    // Start is called before the first frame update
    void Start()
    {
        //clouds = new List<ParticleSystem>();
        StartCoroutine("GetCloudNum");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GetCloudNum()
    {
        yield return new WaitForSeconds(0.2f);

        int i = 0;
        while(true)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
                break;

            ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();
            var coll = particle.collision;
            coll.enabled = true;
            coll.type = ParticleSystemCollisionType.World;
            coll.collidesWith = LayerMask.GetMask("Player");

            //clouds.Add();
            i++;
        }
    }
}
