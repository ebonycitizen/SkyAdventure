using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TurtleShooter : MonoBehaviour
{
    [SerializeField] private GameObject shot;

    [SerializeField] private Transform shotPositionRef;

    [SerializeField] private GameObject shotEffect;

    [SerializeField] private Transform target;

    [SerializeField] private float shotVelocity = 15f;

    public void Shoot(GameObject _target)
    {
        target = _target.transform;
        StartCoroutine(InShooting());
    }

    IEnumerator InShooting()
    {
        shotEffect.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        GameObject shotPrehab = Instantiate(shot) as GameObject;
        shotPrehab.transform.position = shotPositionRef.position;
        Rigidbody rb = shotPrehab.GetComponent<Rigidbody>();
        Vector3 direction = (target.position - transform.position).normalized;

        shotPrehab.transform.DORotateQuaternion(target.rotation, 1);
        rb.AddForce(direction * shotVelocity, ForceMode.VelocityChange);
    }
}
