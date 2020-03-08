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
    Vector2 targetDirection;
    public float minMoveSpeed;
    public float maxMoveSpeed;
    [System.NonSerialized]
    public float moveSpeed;
    public float OxyDamage;
    public bool canMove;
    private ParticleSystem particle; 

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sub = GameObject.Find("Submarine");
        _rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bar = GameObject.Find("OxygenBar");

        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Update()
    {
        
        if (gameObject.GetComponent<BigChase>() != null) {
            canMove = gameObject.GetComponent<BigChase>().canMove;
        }
        else
        {
            canMove = true;
        }

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
        if (canMove)
        {
            MoveEnemy();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Wall")) // enemy hitting ship depletes oxygen
        {
            bar.GetComponent<OxygenBar>().LoseOxy(OxyDamage);
            Destroy(gameObject);
        }
    }

    public void EyeFlash()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        //particle.Play();
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
