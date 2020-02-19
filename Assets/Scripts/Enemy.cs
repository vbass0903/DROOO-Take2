using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _rb;
    private GameObject sub;
    public GameObject bar;
    public float hitpoints;
    public string nam;
    public Vector2 targetDirection;
    public float moveSpeed;

    public Enemy(int hp, string ID) 
    {
        hitpoints = hp;
        nam = ID;
    }
    void Start()
    {
        sub = GameObject.Find("Submarine");
        _rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(2f, 5f);
    }

    void Update()
    {
        //en.transform.RotateAround(sub.transform.position, Vector3.back, 20f * Time.deltaTime);
        bar = GameObject.Find("OxygenBar");
        MoveEnemy();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Wall")) // enemy hitting ship depletes oxygen
        {
            bar.GetComponent<OxygenBar>().LoseOxy(25f);
            Destroy(gameObject);
        }
    }
    private void MoveEnemy()
    {
        if (sub != null)
        {
            targetDirection = (sub.transform.position - transform.localPosition).normalized;
            _rb.velocity = new Vector2(targetDirection.x * moveSpeed, targetDirection.y * moveSpeed);
        }
        else
            _rb.velocity = Vector3.zero;
    }
}
