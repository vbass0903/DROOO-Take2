using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purifierProgress : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject purifier;
    public float progress = 0f;
    float offset = 0f;
    float compareProgress = 1f;
    float startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.y;
        purifier = transform.parent.gameObject;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(purifier.GetComponent<Purifier>().startTime != 0f);
        if (purifier.GetComponent<Purifier>().startTime != 0f)
        {
            offset = Time.time - purifier.GetComponent<Purifier>().startTime;
            progress = offset / purifier.GetComponent<Purifier>().surviveTime;
            compareProgress = 1 - progress;

            Debug.Log(new Vector3(offset, progress, compareProgress));

            transform.localScale = new Vector3(transform.localScale.x, startScale - progress, transform.localScale.z);
        }
    }
}
