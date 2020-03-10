using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMove>().isOnLadder = true;
        }
    }

    void onTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited");
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMove>().isOnLadder = false;
        }
    }
}
