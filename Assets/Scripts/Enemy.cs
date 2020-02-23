using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _rb;
    private GameObject sub;
    public GameObject bar;
    SpriteRenderer sprite;
    public float hitpoints;
    public string nam;
    public Vector2 targetDirection;
    public float moveSpeed;
    bool isBig;

    public Enemy(int hp, string ID) 
    {
        hitpoints = hp;
        nam = ID;
    }
    void Start()
    {
        sub = GameObject.Find("Submarine");
        _rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isBig = false;
        if (gameObject.name == "BigEnemy")
        {
            isBig = true;
            moveSpeed = 1f;
        }
        else
        {
            moveSpeed = Random.Range(2f, 3f);
        }
    }

    void Update()
    {
        //en.transform.RotateAround(sub.transform.position, Vector3.back, 20f * Time.deltaTime);
        bar = GameObject.Find("OxygenBar");
        MoveEnemy();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isBig)
        {
            if (col.CompareTag("Ground") || col.CompareTag("Wall")) // enemy hitting ship depletes oxygen
            {
                bar.GetComponent<OxygenBar>().LoseOxy(200f);
            }
        }
        else
        {
            if (col.CompareTag("Ground") || col.CompareTag("Wall")) // enemy hitting ship depletes oxygen
            {
                bar.GetComponent<OxygenBar>().LoseOxy(25f);
                Destroy(gameObject);
            }
        }
    }

    public void EyeFlash()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 2; n++)
        {
            ChangeColor(Color.white);
            yield return new WaitForSeconds(0.1f);
            ChangeColor(Color.red);
            yield return new WaitForSeconds(0.1f);
            ChangeColor(Color.white);
        }
    }
    private void ChangeColor(Color color)
    {
        sprite.color = color;
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
