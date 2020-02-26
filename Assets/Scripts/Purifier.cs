using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purifier : MonoBehaviour
{
    GameObject submarine;
    GameObject purifierArrow;
    GameObject spawnerSwarm;
    GameObject bar;
    SpriteRenderer sprite;
    public float startTime;
    public float endTime;
    public float surviveTime = 1f;
    public bool completed = false;
    public bool inProgress = false;

    void Start()
    {
        completed = false;
        bar = GameObject.Find("OxygenBar");
        submarine = GameObject.Find("Submarine");
        sprite = GetComponent<SpriteRenderer>();
        purifierArrow = transform.Find("PurifierArrow").gameObject; 
        spawnerSwarm = GameObject.Find("SwarmSpawners");
    }

    void Update()
    {
        if (completed)
        {
            submarine.GetComponentInParent<Submarine>().isDocked = false;
            sprite.color = new Color(1, 1, 1, 1);
            this.gameObject.SetActive(false);
        }

        if (inProgress)
        {
            purifierArrow.SetActive(false);
        }

        if (inProgress && Time.time > endTime)
        {
            bar.GetComponent<OxygenBar>().GainOxy(352f);
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
