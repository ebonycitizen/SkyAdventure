using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShooter : MonoBehaviour
{
    [SerializeField] private GameObject shot;

    [SerializeField] private Transform shotPositionRef;

    [SerializeField] private GameObject shotEffect;

    public void Shoot()
    {
        StartCoroutine(InShooting());
    }

    IEnumerator InShooting()
    {
        shotEffect.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        GameObject shotPrehab = Instantiate(shot) as GameObject;
        shotPrehab.transform.position = shotPositionRef.position;
        Rigidbody rb = shotPrehab.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*15, ForceMode.VelocityChange);
    }
}
