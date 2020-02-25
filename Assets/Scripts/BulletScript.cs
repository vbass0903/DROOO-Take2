using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bar;
    public float oxyGain = 5f;
    void Start()
    {

    }
    void Update()
    {
        bullet = GameObject.Find("Bullet(Clone)");
        bar = GameObject.Find("OxygenBar");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().hitpoints -= 1;
            col.gameObject.GetComponent<Enemy>().EyeFlash();
            Destroy(gameObject);
        }
        else if (col.CompareTag("Ground") || col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (col.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("BigEnemy"))
        {
            Destroy(gameObject);
            col.GetComponent<Enemy>().hitpoints -= 1;
            col.gameObject.GetComponent<Enemy>().moveSpeed += 0.05f;
            col.gameObject.GetComponent<Enemy>().EyeFlash();

        }
    }

}
