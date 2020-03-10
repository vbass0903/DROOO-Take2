using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public int hitpoints;
    public GameObject boss;
    public GameObject enemy;
    public bool canSpawn;
    SpriteRenderer sprite;
    GameObject bar;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f);
        canSpawn = true;
        sprite = GetComponent<SpriteRenderer>();
        boss = GameObject.Find("Boss");
        bar = GameObject.Find("OxygenBar");
    }

    void Update()
    {
        if(hitpoints <= 0)
        {
            canSpawn = false;
            boss.GetComponent<BossScript>().numArms -= 1;
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        if (canSpawn)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
    public void ColorFlash(Color color)
    {
        StartCoroutine(Flash(color));
    }

    IEnumerator Flash(Color color)
    {
        for (int n = 0; n < 2; n++)
        {
            ChangeColor(Color.white);
            yield return new WaitForSeconds(0.1f);
            ChangeColor(color);
            yield return new WaitForSeconds(0.1f);
            ChangeColor(Color.white);
        }
    }
    private void ChangeColor(Color color)
    {
        sprite.color = color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Wall"))
        {
            bar.GetComponent<OxygenBar>().LoseOxy(10f);
        }
    }
}
