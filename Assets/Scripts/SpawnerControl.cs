using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{

    public Transform[] spawns;
    public GameObject enemy;
    int randomSpawn;
    public static bool spawnAllowed;
    public float SpawnEveryXSeconds = 3f;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("EnemySpawn", 0f, SpawnEveryXSeconds);
    }

    void EnemySpawn()
    {
        if (spawnAllowed)
        {
            randomSpawn = Random.Range(0, spawns.Length);
            Instantiate(enemy, spawns[randomSpawn].position, Quaternion.identity);
        }
    }
    
    void Update()
    {
        
    }
}
