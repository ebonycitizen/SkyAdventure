using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private GameObject shot;

    [SerializeField] private Transform shotPositionRef;

    [SerializeField] private float shotVelocity = 15f;

    private Transform target;

    public bool isShooting = false;

    public void Shoot(GameObject _target)
    {
        isShooting = true;
        target = _target.transform;
        StartCoroutine(InShooting());
    }
    IEnumerator InShooting()
    {
        CreateShot(target);
        yield return new WaitForSeconds(1);
    }

    private void CreateShot(Transform _target)
    {
        GameObject shotPrehab = Instantiate(shot) as GameObject;
        shotPrehab.transform.position = shotPositionRef.position;
        Rigidbody rb = shotPrehab.GetComponent<Rigidbody>();
        Vector3 direction = (_target.position - transform.position).normalized;
        rb.AddForce(direction * shotVelocity, ForceMode.VelocityChange);
    }
}
