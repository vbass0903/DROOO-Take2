using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressureBar : MonoBehaviour
{
    public GameObject bar;
    public GameObject sub;
    public float rate;
    public float pressureLevel;
    public float subDepth;
    public void Start()
    {
    }
    
    public void SetPressure(float change)
    {
        bar.transform.localScale = new Vector2(bar.transform.localScale.x * change, bar.transform.localScale.y);
        pressureLevel *= change;
    }

    public void FixedUpdate() 
    {
        
    }
    public void Update()
    {
        GameObject sub = GameObject.Find("Submarine");

        pressureLevel = bar.transform.localScale.x; // 0 , 161
        subDepth = sub.transform.position.y; // ~2.5 to 13

        bar.transform.localScale = new Vector3(bar.transform.localScale.x, bar.transform.localScale.y, bar.transform.localScale.z);




        if (pressureLevel <= 0)
        {

            SceneManager.LoadScene("SampleScene");
            /*sub.GetComponent<Submarine>().hasOxygen = false;
            oxygenLevel = 0;
            bar.transform.localScale = new Vector2(0, bar.transform.localScale.y);
            Destroy(sub.gameObject); // need lose function somewhere*/

        }
        if (pressureLevel > 147f) // 147 is max localScale,  CHANGES IF SUB SCALE CHANGES
        {
            //SceneManager.LoadScene("SampleScene");
        }
    } 
}
