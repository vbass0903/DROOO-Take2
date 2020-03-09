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
    public SpriteRenderer sprite;
    private Color originalColor;
    public void Start()
    {
        GameObject sub = GameObject.Find("Submarine");
        GameObject oBar = GameObject.Find("OxygenBar");
        originalColor = sprite.color;
    }

    public void FixedUpdate() 
    {
        
    }

    public void ColorFlash(Color color)
    {
        StartCoroutine(Swap(color));
    }

    IEnumerator Swap(Color color)
    {
            Color orig_color = sprite.color;
            ChangeColor(color);
            yield return new WaitForSeconds(0f);
            ChangeColor(orig_color);
    }
    private void ChangeColor(Color color)
    {
        sprite.color = color;
    }

    public void Update()
    {
        pressureLevel = pBar.transform.localScale.x; // 0 , 161
        subDepth = sub.transform.position.y; // 
        pressureCalc = 161f * (subDepth + 13f) / 39f; // scales
        pBar.transform.localScale = new Vector3(pressureCalc, pBar.transform.localScale.y, pBar.transform.localScale.z);
 
        if (pressureLevel < 161 && pressureLevel > 135 || pressureLevel < 25 && pressureLevel > 0)
        {
            ColorFlash(Color.white);
        }
        else
        {
            ChangeColor(originalColor);
        }
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
