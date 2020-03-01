using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purifierProgress : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject purifier;
    public float progress = 0f;
    float offset = 0f;
    float startScale;

    void Start()
    {
        startScale = transform.localScale.y;
        purifier = transform.parent.gameObject;
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!(purifier.GetComponent<Purifier>().completed))
        {
            if (purifier.GetComponent<Purifier>().startTime != 0f)
            {
                offset = Time.time - purifier.GetComponent<Purifier>().startTime;
                progress = offset / purifier.GetComponent<Purifier>().surviveTime;
                transform.localScale = new Vector3(transform.localScale.x, startScale - progress, transform.localScale.z);
            }
        }
        
    }
}
