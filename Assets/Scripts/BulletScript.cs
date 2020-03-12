using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bar;
    public GameObject sub;
    public float oxyGain = 5f;
    void Start()
    {

    }
    void Update()
    {
        bullet = GameObject.Find("Bullet(Clone)");
        bar = GameObject.Find("OxygenBar");
        sub = GameObject.Find("Submarine");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.CompareTag("Dummy"))
        {
            col.gameObject.GetComponent<Enemy>().EyeFlash();
            col.GetComponent<Enemy>().hitpoints -= 1;
            
            Destroy(gameObject);
        }
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().EyeFlash();
            col.GetComponent<Enemy>().hitpoints -= 1;
            
            Destroy(gameObject);
        }

        else if (col.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("BigEnemy"))
        {
            col.gameObject.GetComponent<Enemy>().EyeFlash();
            col.GetComponent<Enemy>().hitpoints -= 1;
            col.gameObject.GetComponent<Enemy>().moveSpeed += 0.05f;
            
            Destroy(gameObject);
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
