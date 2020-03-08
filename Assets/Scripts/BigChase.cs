using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChase : MonoBehaviour
{
    public GameObject purifier;
    public GameObject sub;
    public bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "BigEnemy" && sub.transform.position.x < 0)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }
}
