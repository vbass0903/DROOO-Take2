using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purifier : MonoBehaviour
{
    GameObject submarine;
    GameObject bar;
    SpriteRenderer sprite;
    public float startTime;
    public float endTime;
    public float surviveTime = 5f;
    public float oxyGain = 100f;
    public bool completed = false;
    public bool inProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("OxygenBar");
        completed = false;
        submarine = GameObject.Find("Submarine");
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inProgress)
        {
            foreach (Transform spawner in transform)
            {
                spawner.gameObject.GetComponent<SpawnerControl>().spawnAllowed = true;
            }
        }

        if (completed)
        {
            bar.GetComponent<OxygenBar>().GainOxy(oxyGain);
            submarine.GetComponentInParent<Submarine>().isDocked = false;
            sprite.color = new Color(1, 1, 1, 1);
            foreach (Transform spawner in transform)
            {
                spawner.gameObject.GetComponent<SpawnerControl>().spawnAllowed = false;
            }
            gameObject.SetActive(false);
        }

        if (inProgress && Time.time > endTime)
        {
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
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dock")
        {
            collision.gameObject.GetComponentInParent<Submarine>().isDocked = false;
        }
    }

}
