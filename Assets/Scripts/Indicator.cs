using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    GameObject submarine;
    GameObject[] targets;
    GameObject curTarget;
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        curTarget = FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        curTarget = FindTarget();
        Vector3 targetDir = curTarget.transform.position;
        Debug.Log(targetDir);
        transform.position = targetDir.normalized;
        //transform.LookAt(curTarget.transform, Vector3.left);
    }

    GameObject FindTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Purifier");
        for (int i = 0; i < targets.Length; i++)
        {
            if (!(targets[i].GetComponent<Purifier>().completed))
            {
                return targets[i];
            }
        }
        return null;
    }
}
