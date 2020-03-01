using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    GameObject submarine, minimap;
    GameObject purifier;
    public GameObject[] children;
    bool pilotSpeedUp = false, minimapOnUp = false, turretTripleUp = false;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        minimap = GameObject.Find("MinimapWindow");
        submarine = GameObject.Find("Submarine");
        purifier = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            turnOnBubbles();
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
}
