using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShot : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5;

    [SerializeField] private Transform crashEff;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            crashEff.GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
