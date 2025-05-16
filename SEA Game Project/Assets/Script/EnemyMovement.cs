using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour 
{
    public float speed;
    private bool isChasing;
    private Rigidbody2D rb;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.linearVelocity = Vector2.zero;
        isChasing = false;
    }
}
