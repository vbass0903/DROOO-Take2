using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBubble : MonoBehaviour
{
    GameObject upgradeMan, purifier;
    public bool active;

    void Start()
    {
        active = false;
        upgradeMan = transform.parent.gameObject;
        gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Wall" || collision.tag == "Ground")
        {
            Destroy(gameObject);
            upgradeMan.GetComponent<UpgradeManager>().UpgradeStation(gameObject.name);
            upgradeMan.GetComponent<UpgradeManager>().turnOffBubbles();
        }
    }
}
