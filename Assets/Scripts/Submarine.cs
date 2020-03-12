using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    GameObject sub;
    public bool isDocked = false;
    public bool hasOxygen = true;
    public bool canDamageBoss = false;

    void Start()
    {
        sub = GameObject.Find("Submarine");
    }

    void Update()
    {
        if (!(sub.GetComponent<Submarine>().isDocked))
        {
            sub.transform.position -= new Vector3(0f, 0.005f, 0f);
        }
    }

}
