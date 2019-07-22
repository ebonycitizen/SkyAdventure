using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject targetRight;

    [SerializeField]
    private GameObject targetLeft;

    [SerializeField]
    private GameObject enemyMole;

    [SerializeField]
    private GameObject enemyPenguin;

    [SerializeField]
    private Transform[] molesSpawnPos;

    [SerializeField]
    private Transform[] penguinsSpawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
