using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    GameObject boss;
    GameObject rotatePoint;
    GameObject spawnerSwarm;
    GameObject bar;
    GameObject sub;
    public GameObject[] arms;
    public GameObject[] enemy;
    SpriteRenderer sprite;
    public bool isVulnerable;
    public float hitpoints;
    public float numArms;
    public bool isDead;
    public float bossSpeed;

    void Start()
    {
        boss = GameObject.Find("Boss");
        rotatePoint = GameObject.Find("RotatePoint");
        arms = GameObject.FindGameObjectsWithTag("Arm");
        bar = GameObject.Find("OxygenBar");
        sub = GameObject.Find("Submarine");
        spawnerSwarm = GameObject.Find("SwarmSpawners");
        sprite = GetComponent<SpriteRenderer>();
        isVulnerable = false;
        numArms = arms.Length;
        isDead = false;
    }

    void Update()
    {
        if (hitpoints <= 0)
        {
            ChangeColor(Color.black);
            isDead = true;
        }
        if (!isDead)
        {
            //boss.transform.RotateAround(rotatePoint.transform.position, Vector3.back, bossSpeed * Time.deltaTime);
            switch (numArms)
            {
                case 0:
                    isVulnerable = true;
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = true;
                    break;
                case 2:
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = false;
                    break;
                case 5:
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = true;
                    break;
                case 6:
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = false;
                    break;
                case 7:
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = true;
                    break;
                case 8:
                    spawnerSwarm.GetComponent<SpawnerControl>().spawnAllowed = false;
                    break;
            }   
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
            bar.GetComponent<OxygenBar>().LoseOxy(20f);
        }
    }
}
