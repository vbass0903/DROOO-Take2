using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColor : MonoBehaviour
{
    GameObject[] players;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0f,1f) , Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
