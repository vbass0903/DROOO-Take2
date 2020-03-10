using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Station : MonoBehaviour
{
    GameObject attachUI;
    GameObject detachUI;
    Vector3 playerPos;
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
            //Debug.Log("Entered");
            sprite.color = new Color(1, 1, 1, 0.5f);

            switch (gameObject.name)
            {
                case "TurretStation1":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
                case "TurretStation2":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
                case "TurretStation3":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
                case "TurretStation4":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
                case "PilotStation":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
                case "MinimapStation":
                    playerPos = transform.TransformPoint(Vector3.right * 2);
                    break;
            }
            collision.gameObject.GetComponent<playerMove>().nearStation = true;
            collision.gameObject.GetComponent<playerStation>().attachedStation = gameObject.name;
        }

        if (collision.tag == "Player" && collision.gameObject.GetComponent<playerMove>().isAttached)
        {
            //Debug.Log("Attached");
            //collision.gameObject.transform.position = gameObject.transform.position;
            sprite.color = new Color(1, 1, 1, 1);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Exited");
            sprite.color = new Color(1, 1, 1, 1);

            //collision.gameObject.transform.position = playerPos;
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
