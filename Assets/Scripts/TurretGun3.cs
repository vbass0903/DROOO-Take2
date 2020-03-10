using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretGun3 : MonoBehaviour
{
    GameObject Player;
    GameObject Turret;
    GameObject Body;

    public Rigidbody2D Bullet;
    public Rigidbody2D new_Bullet;

    public float speed;
    public float timeBetweenShots;
    public float timeDestroy;

    void Awake()
    {

    }

    void Start()
    {
        Player = GameObject.Find("Player");
        Turret = GameObject.Find("TurretGun3");
        Body = GameObject.Find("TurretBody3");

        speed = 10f;
        timeBetweenShots = 0.5f;
        timeDestroy = 4f;
    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Turret.transform.RotateAround(Body.transform.position, Vector3.forward, 100f * Time.deltaTime);
        }
        if (collision.CompareTag("Wall"))
        {
            Turret.transform.RotateAround(Body.transform.position, Vector3.back, 100f * Time.deltaTime);
        }
    }

}