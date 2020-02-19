﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Station : MonoBehaviour
{
    GameObject attachUI;
    GameObject detachUI;
    SpriteRenderer sprite;
    public int hitpoints;
    public string nam;


    public Station(int hp, string ID) //Constructor
    {
        hitpoints = hp;
        nam = ID;
    }

    void Awake()
    {
        sprite = transform.parent.GetComponent<SpriteRenderer>();
        attachUI = GameObject.Find("attachUI");
        detachUI = GameObject.Find("detachUI");
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.color = new Color(.5f, .5f, .5f, 1);

            collision.gameObject.GetComponent<playerMove>().nearStation = true;
            collision.gameObject.GetComponent<playerStation>().attachedStation = gameObject.name;
        }

        if (collision.tag == "Player" && collision.gameObject.GetComponent<playerMove>().isAttached)
        {
            sprite.color = new Color(1, 1, 0, 1);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.color = new Color(0, 0, 0, 1);

            collision.gameObject.GetComponent<playerMove>().nearStation = false;
            collision.gameObject.GetComponent<playerStation>().attachedStation = null;
        }
    }

    bool CheckAttached(GameObject[] Players)
    {
        bool check = true;
        for (int i = 0; i < Players.Length; i++)
        {
            if (!(Players[i].GetComponent<playerMove>().isAttached))
            {
                check = false;
            }
        }
        return check;
    }
}
