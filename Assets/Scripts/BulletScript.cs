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
        if (col.CompareTag("Dummy"))
        {
            col.GetComponent<Enemy>().hitpoints -= 1;
            col.gameObject.GetComponent<Enemy>().EyeFlash();
            Destroy(gameObject);
        }
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
            col.GetComponent<Enemy>().hitpoints -= 1;
            col.gameObject.GetComponent<Enemy>().moveSpeed += 0.05f;
            col.gameObject.GetComponent<Enemy>().EyeFlash();

        }
        else if (col.CompareTag("Arm"))
        {
            col.GetComponent<Arm>().hitpoints -= 1;
            col.gameObject.GetComponent<Arm>().ColorFlash(Color.red);
            Destroy(gameObject);
        }
        else if (col.CompareTag("Boss"))
        {
            if (col.GetComponent<BossScript>().isDead == true)
            {
                Destroy(gameObject);
            }
            else if (col.GetComponent<BossScript>().isVulnerable == true)
            {
                col.GetComponent<BossScript>().hitpoints -= 1;
                col.gameObject.GetComponent<BossScript>().ColorFlash(Color.red);
                Destroy(gameObject);
            }
            else
            {
                col.gameObject.GetComponent<BossScript>().ColorFlash(Color.grey);
                Destroy(gameObject);
            }
        }
    }
}
