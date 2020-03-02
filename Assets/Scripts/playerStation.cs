using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerStation : MonoBehaviour
{
    GameObject Player;
    GameObject TurretGun;
    GameObject TurretBody;

    public Rigidbody2D Bullet;
    public Rigidbody2D new_Bullet;

    public float speed;
    public float timeBetweenShots;
    public float timeDestroy;

    public bool isAttach = false;
    public bool isLeftTurret = false;
    public bool isRightTurret = false;
    public bool turretLUpgrade = false;
    public bool turretRUpgrade = false;
    public float moveSpeed = 5f; //Copied from playerMove, can be changed to change submarine move speed
    public string attachedStation = null;
    public float turretRotateSpeed = 100f;
    private float joystickAngle;
    private float angleModifier;
    public GameObject[] players;
    GameObject minimap;
    Vector2 move;

    void Awake()
    {

    }

    void Start()
    {
        Player = GameObject.Find("Player");
        minimap = GameObject.Find("MinimapWindow");
        speed = 10f;
        timeBetweenShots = 0.5f;
        timeDestroy = 3f;
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void FixedUpdate()
    {
        if (isAttach)
        {
            switch (attachedStation)
            {
                case "MapStation":
                    minimap.GetComponent<playerUI>().isTouching = true;

                    break;

                case "PilotStation":
                    GameObject submarine = GameObject.Find("Submarine");

                    if (!(submarine.GetComponent<Submarine>().isDocked)) //Stops Movement while docked to purifier
                    {
                        move = gameObject.GetComponent<playerMove>().move; //Reads input from joystick
                        Vector3 movement = new Vector3(move.x, move.y, 0f);
                        submarine.transform.position += movement * Time.fixedDeltaTime * moveSpeed; //Update position of submarine
                        for (int i = 0; i < players.Length; i++)
                        {
                            players[i].transform.position += movement * Time.fixedDeltaTime * moveSpeed; //Update position of player relative to submarine
                        }
                    }
                    break;
                case "TurretStation1":
                    isRightTurret = true;
                    TurretGun = GameObject.Find("TurretGun1");
                    TurretBody = GameObject.Find("TurretBody1");

                    move = gameObject.GetComponent<playerMove>().move; //Get joystick input

                    joystickAngle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
                    TurretBody.transform.rotation = Quaternion.AngleAxis(joystickAngle + 90, Vector3.forward);
                    break;
                case "TurretStation2":
                    isLeftTurret = true;
                    TurretGun = GameObject.Find("TurretGun2");
                    TurretBody = GameObject.Find("TurretBody2");

                    move = gameObject.GetComponent<playerMove>().move; //Get joystick input

                    joystickAngle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
                    TurretBody.transform.rotation = Quaternion.AngleAxis(joystickAngle - 90, Vector3.forward);
                    break;
            }
        }

        if (!playersScan())
        {
            minimap.GetComponent<playerUI>().isTouching = false;
        }
    }

    bool playersScan()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<playerStation>().attachedStation == "MapStation")
            {
                return true;
            }
        }
        return false;
    }

    public void Attach(InputAction.CallbackContext context)
    {
        isAttach = true;
    }

    public void Detach(InputAction.CallbackContext context)
    {
        isAttach = false;
        isLeftTurret = false;
        isRightTurret = false;
    }

    public void Fire(InputAction.CallbackContext context)
    {

        if (isAttach && isRightTurret)
        {
            TurretGun = GameObject.Find("TurretGun1");
            TurretBody = GameObject.Find("TurretBody1");

            if (turretRUpgrade)
            {
                new_Bullet = Instantiate(Bullet, (TurretGun.transform.position + new Vector3(0.5f,0.5f,0)), TurretGun.transform.rotation);
                new_Bullet.velocity = (-TurretGun.transform.right + new Vector3(0f,0.075f,0f)) * speed;
                Destroy(new_Bullet.gameObject, timeDestroy);

                new_Bullet = Instantiate(Bullet, (TurretGun.transform.position - new Vector3(0.5f, 0.5f, 0)), TurretGun.transform.rotation);
                new_Bullet.velocity = (-TurretGun.transform.right - new Vector3(0f, 0.075f, 0f)) * speed;
                Destroy(new_Bullet.gameObject, timeDestroy);
            }
            

            new_Bullet = Instantiate(Bullet, TurretGun.transform.position, TurretGun.transform.rotation);
            new_Bullet.velocity = -TurretGun.transform.right * speed;
            Destroy(new_Bullet.gameObject, timeDestroy);

            
        }
        else if (isAttach && isLeftTurret)
        {
            TurretGun = GameObject.Find("TurretGun2");
            TurretBody = GameObject.Find("TurretBody2");

            if (turretLUpgrade)
            {
                new_Bullet = Instantiate(Bullet, (TurretGun.transform.position + new Vector3(0.5f, 0.5f, 0)), TurretGun.transform.rotation);
                new_Bullet.transform.rotation = TurretGun.transform.rotation * new Quaternion(0, 0, 180, 0);
                new_Bullet.velocity = (TurretGun.transform.right + new Vector3(0f, 0.075f, 0f)) * speed;
                Destroy(new_Bullet.gameObject, timeDestroy);

                new_Bullet = Instantiate(Bullet, (TurretGun.transform.position - new Vector3(0.5f, 0.5f, 0)), TurretGun.transform.rotation);
                new_Bullet.transform.rotation = TurretGun.transform.rotation * new Quaternion(0, 0, 180, 0);
                new_Bullet.velocity = (TurretGun.transform.right - new Vector3(0f, 0.075f, 0f)) * speed;
                Destroy(new_Bullet.gameObject, timeDestroy);
            }

            new_Bullet = Instantiate(Bullet, TurretGun.transform.position, TurretGun.transform.rotation);
            new_Bullet.transform.rotation = TurretGun.transform.rotation * new Quaternion(0, 0, 180, 0);
            new_Bullet.velocity = TurretGun.transform.right * speed;
            Destroy(new_Bullet.gameObject, timeDestroy);
        }
    }
}

