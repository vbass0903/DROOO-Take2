using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Purifier : MonoBehaviour
{
    GameObject submarine;
    GameObject purifierArrow;
    GameObject spawnerSwarm;
    GameObject bar;
    SpriteRenderer sprite;
    Scene scene;
    public float startTime;
    public float endTime;
    public float surviveTime = 1f;
    public float oxyGain;
    public bool completed = false;
    public bool inProgress = false;

    void Start()
    {
        //scene = SceneManager.GetActiveScene();
        //DontDestroyOnLoad(this.gameObject);
        completed = false;
        bar = GameObject.Find("OxygenBar");
        submarine = GameObject.Find("Submarine");
        sprite = GetComponent<SpriteRenderer>();
        purifierArrow = transform.Find("PurifierArrow").gameObject; 
        spawnerSwarm = GameObject.Find("SwarmSpawners");
    }

    void Update()
    {
        //if (scene.name == "BossScene")
        //{
        //    sprite.enabled = false;
        //}
        if (completed)
        {
            inProgress = false;
            sprite.color = new Color(1, 1, 1, 1);
            //this.gameObject.SetActive(false);
        }

        if (inProgress)
        {
            purifierArrow.SetActive(false);
        }

        if (inProgress && Time.time > endTime)
        {
            bar.GetComponent<OxygenBar>().GainOxy(oxyGain);
            submarine.GetComponentInParent<Submarine>().isDocked = false;
            spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = false;
            completed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Dock" && !completed)
        {
            startTime = Time.time;
            endTime = startTime + surviveTime;
            inProgress = true;

            sprite.color = new Color(1, 1, 0, 1);

            submarine.GetComponentInParent<Submarine>().isDocked = true;
            spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dock")
        {
            collision.gameObject.GetComponentInParent<Submarine>().isDocked = false;
            spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = false;
        }
    }

}
