using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressureBar : MonoBehaviour
{
    public GameObject pBar;
    public GameObject oBar;
    public GameObject sub;
    public float rate;
    public float pressureLevel;
    public float subDepth;
    public float pressureCalc;
    public void Start()
    {
        GameObject sub = GameObject.Find("Submarine");
        GameObject oBar = GameObject.Find("OxygenBar");
    }

    public void FixedUpdate() 
    {
        
    }
    public void Update()
    {
        pressureLevel = pBar.transform.localScale.x; // 0 , 161
        subDepth = sub.transform.position.y; // 
        pressureCalc = 161f * (subDepth + 13f) / 39f;
        pBar.transform.localScale = new Vector3(pressureCalc, pBar.transform.localScale.y, pBar.transform.localScale.z);

        if (pressureLevel <= 0)
        {
            oBar.GetComponent<OxygenBar>().LoseOxy(0.1f);
        }
        if (pressureLevel > 161f) // 161 is max localScale,  CHANGES IF SUB SCALE CHANGES
        {
            oBar.GetComponent<OxygenBar>().LoseOxy(0.1f);
        }
    } 
}
