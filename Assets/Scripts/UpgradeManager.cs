using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    GameObject submarine, minimap;
    GameObject[] players;
    GameObject purifier;
    public GameObject[] children;
    bool pilotSpeedUp = false, minimapOnUp = false, turretTripleUp = false;
    bool active;

    void Start()
    {
        minimap = GameObject.Find("MinimapWindow");
        submarine = GameObject.Find("Submarine");
        purifier = transform.parent.gameObject;
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (!active)
        {
            turnOnBubbles();
        }

        if (turretTripleUp)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<playerStation>().turretLUpgrade = true;
                players[i].GetComponent<playerStation>().turretRUpgrade = true;
            }
        }
        
        if (pilotSpeedUp)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<playerStation>().moveSpeed = 8f;
            }
        }

        if (minimapOnUp)
        {
            minimap.GetComponent<playerUI>().isTouching = true;
        }
        
    }

    public void UpgradeStation(string stationName)
    {

        switch (stationName)
        {
            case "PilotUpgrade":
                if (!pilotSpeedUp)
                {
                    pilotSpeedUp = true;
                }
                break;
            case "TurretUpgrade":
                if (!turretTripleUp)
                {
                    turretTripleUp = true;
                }
                break;
            case "MinimapUpgrade":
                if (!minimapOnUp)
                {
                    minimapOnUp = true;
                }

                break;
        }
    }

    void turnOnBubbles()
    {
        if (purifier.GetComponent<Purifier>().completed)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].SetActive(true);
            }
            active = true;
        }
    }

    public void turnOffBubbles()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(false);
        }
    }
}
