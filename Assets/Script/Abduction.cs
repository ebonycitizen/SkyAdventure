using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abduction : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private List<GameObject> people;

    private void OnDisable()
    {
        if (people.Count == 0)
            return;

        foreach (GameObject p in people)
        {
            if (p == null)
                continue;
            p.GetComponent<Rigidbody>().isKinematic = false;
        }

        people.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        people = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject p in people)
        {
            if (p == null)
                continue;
            Vector3 velocity = (transform.position - p.transform.position).normalized * speed * Time.deltaTime;
            p.transform.position += velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "People")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            people.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "People" && people.Contains(other.gameObject))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            people.Remove(other.gameObject);
        }
    }
}
