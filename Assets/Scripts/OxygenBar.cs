using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    public GameObject bar;
    public GameObject sub;
    public float oxygenDepleteRate = 0.3f;
    public float oxygenLevel;
    public void Start()
    {
        GameObject bar = GameObject.Find("Bar");
        GameObject sub = GameObject.Find("Submarine");
        oxygenLevel = bar.transform.localScale.x;
    }

    public void DecreaseOxy(float change)
    {
        bar.transform.localScale = new Vector2(bar.transform.localScale.x - change, bar.transform.localScale.y);
        oxygenLevel -= change;
    }

    public void GainOxy(float change)
    {
        bar.transform.localScale = new Vector2(bar.transform.localScale.x + change, bar.transform.localScale.y);
        oxygenLevel += change;
    }
    
    public void LoseOxy(float change)
    {
        bar.transform.localScale = new Vector2(bar.transform.localScale.x - change, bar.transform.localScale.y);
        oxygenLevel -= change;
    }

    private void ChangeColor(Color color)
    {
        bar.GetComponent<SpriteRenderer>().color = color;
    }

    public void FixedUpdate() 
    {
        DecreaseOxy(oxygenDepleteRate); // idk if this needs to be in update or fixedupdate
    }

    public void Update()
    {
        GameObject sub = GameObject.Find("Submarine");
        if (oxygenLevel <= 0)
        {
            Debug.Log("ran out of oxygen");
            Destroy(sub.gameObject); // need lose function somewhere
            oxygenLevel = 0;
            bar.transform.localScale = new Vector2(0, bar.transform.localScale.y);
            
        }
        if(oxygenLevel > 352) // 352 is max localScale,  CHANGES IF GAME SCALE CHANGES
        {
            oxygenLevel = 352;
            bar.transform.localScale = new Vector2(352, bar.transform.localScale.y);
        }

    }
}
