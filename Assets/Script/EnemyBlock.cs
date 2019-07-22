using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    private GameObject[] enemies;

    private void Awake()
    {
        enemies = new GameObject[transform.childCount];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject;
            enemies[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enemies != null && other.tag == "MainCamera")
        {
            foreach (GameObject enemy in enemies)
                enemy.SetActive(true);

            enemies = null;
        }
    }
}
