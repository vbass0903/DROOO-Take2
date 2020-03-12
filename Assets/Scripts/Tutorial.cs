using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject[] general;
    public GameObject submarine;
    public GameObject purifier;
    public GameObject upgrades;
    public GameObject[] players;
    public GameObject[] enemies;
    float time;
    public int stage;
    bool killed = true;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Dummy");


        for (int i = 1; i < general.Length; i++) //Hide every text, but show the first one
        {
            Hide(general[i]);
        }

        Show(general[0]);

        stage = 0;
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Dummy");

        if (stage == 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if ((players[i].GetComponent<playerStation>().attachedStation == "TurretStation1" || players[i].GetComponent<playerStation>().attachedStation == "TurretStation2" 
                    || players[i].GetComponent<playerStation>().attachedStation == "TurretStation3" || players[i].GetComponent<playerStation>().attachedStation == "TurretStation4")
                    && players[i].GetComponent<playerStation>().isAttach)
                {
                    stage = 1;
                }
            }
        }

        killed = true;

        if (stage == 1)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<Enemy>().hitpoints > 0)
                {
                    killed = false;
                }
            }

            if (killed)
            {
                stage = 2;
            }
        }

        if (stage == 2)
        {
            if (submarine.transform.position.x >= -51.364f)
            {
                stage = 3;
            }
        }

        if (stage == 3)
        {
            if (submarine.GetComponent<Submarine>().isDocked)
            {
                time = Time.time;
                stage = 4;
            }
        }

        if (stage == 4)
        {
            if (purifier.GetComponent<Purifier>().completed)
            {
                stage = 5;
            }
        }

        if (stage == 5)
        {
            if (upgrades.GetComponent<UpgradeManager>().pilotSpeedUp || upgrades.GetComponent<UpgradeManager>().minimapOnUp  || upgrades.GetComponent<UpgradeManager>().turretTripleUp)
            {
                stage = 6;
            }
        }


        switch (stage)
        {
            case 1:
                Hide(general[0]);
                Show(general[1]);
                break;
            case 2:
                Show(general[2]);
                Hide(general[1]);

                submarine.GetComponent<Submarine>().isDocked = false;
                break;
            case 3:
                Show(general[3]);
                Hide(general[2]);
                break;
            case 4:
                Show(general[4]);
                Hide(general[3]);
                break;
            case 5:
                Show(general[5]);
                Hide(general[4]);
                break;
            case 6:
                Show(general[6]);
                Hide(general[5]);

                if ((Time.time - time) >= 33f)
                {
                    SceneManager.LoadScene("SampleScene");
                }
                break;
        }
    }

    void Hide(GameObject go)
    {
        go.GetComponent<CanvasGroup>().alpha = 0f; //this makes everything transparent
        go.GetComponent<CanvasGroup>().blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void Show(GameObject go)
    {
        go.GetComponent<CanvasGroup>().alpha = 1f;
        go.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
