using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLadder : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMove>().isOnLadder = true;
            collision.gameObject.GetComponent<playerMove>().isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMove>().isOnLadder = false;
            collision.gameObject.GetComponent<playerMove>().isGrounded = false;
        }
    }
}
