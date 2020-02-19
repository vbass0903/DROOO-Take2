using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{

    public Transform[] spawns;
    public GameObject enemy;
    int randomSpawn;
    public bool spawnAllowed;
    public float SpawnEveryXSeconds = 3f;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = false;
        InvokeRepeating("EnemySpawn", 0f, SpawnEveryXSeconds);
    }

    void EnemySpawn()
    {
        if (spawnAllowed)
        {
            randomSpawn = Random.Range(0, spawns.Length);
            if (randomSpawn < 4)
            {
                Instantiate(enemy, spawns[randomSpawn].position, Quaternion.identity);
            }
            else //flip enemy to face right because spawners 5-8 are to the right of the ship
            {
                Instantiate(enemy, spawns[randomSpawn].position, new Quaternion(Quaternion.identity.x,
                                                                                Quaternion.identity.y + 180,
                                                                                Quaternion.identity.z,
                                                                                Quaternion.identity.w));
            }
        }
    }
    
    void Update()
    {
        
    }
}
