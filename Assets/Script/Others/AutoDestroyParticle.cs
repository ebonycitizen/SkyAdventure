using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem partcleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, (float)partcleSystem.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
