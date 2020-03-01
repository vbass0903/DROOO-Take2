using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    public GameObject bar;
    public GameObject sub;
    public float oxygenDepleteRate;
    public float oxygenLevel;
    public void Start()
    {
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
        if (!(sub.gameObject.GetComponent<Submarine>().isDocked))
        {
            DecreaseOxy(oxygenDepleteRate); // idk if this needs to be in update or fixedupdate
        }
        
    }

    public void Update()
    {
        GameObject sub = GameObject.Find("Submarine");
        if (oxygenLevel <= 0)
        {
            sub.GetComponent<Submarine>().hasOxygen = false;
            oxygenLevel = 0;
            bar.transform.localScale = new Vector2(0, bar.transform.localScale.y);
            Destroy(sub.gameObject); // need lose function somewhere

        }
        if (oxygenLevel > 352f) // 352 is max localScale,  CHANGES IF GAME SCALE CHANGES
        {
            oxygenLevel = 352f;
            bar.transform.localScale = new Vector2(352f, bar.transform.localScale.y);
        }
    }
}
