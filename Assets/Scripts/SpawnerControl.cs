using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{

    public Transform[] spawns;
    public GameObject[] enemy;
    int randomEnemy;
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
            randomEnemy = Random.Range(0, enemy.Length);
            randomSpawn = Random.Range(0, spawns.Length);
            if (randomSpawn < 4)
            {
                Instantiate(enemy[randomEnemy], spawns[randomSpawn].position, Quaternion.identity);
            }
            else 
            {
                Instantiate(enemy[randomEnemy], spawns[randomSpawn].position, new Quaternion(Quaternion.identity.x,
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
