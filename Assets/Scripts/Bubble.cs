using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float oxyGain;
    GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("OxygenBar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Ground")
        {
            Destroy(gameObject);
            bar.GetComponent<OxygenBar>().GainOxy(oxyGain);
        }
    }
}
