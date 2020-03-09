using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            SceneManager.LoadScene("SampleScene");
            /*sub.GetComponent<Submarine>().hasOxygen = false;
            oxygenLevel = 0;
            bar.transform.localScale = new Vector2(0, bar.transform.localScale.y);
            Destroy(sub.gameObject); // need lose function somewhere*/

        }
        if (oxygenLevel > 161f) // 161 is max localScale,  CHANGES IF SUB SCALE CHANGES
        {
            oxygenLevel = 161f;
            bar.transform.localScale = new Vector2(161f, bar.transform.localScale.y);
        }
    }
}
