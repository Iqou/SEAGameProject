using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour 
{
    public float speed;
    public float attackRange ;
    public float attackCooldown ;
    public float playerDetectRange ;
    public Transform detectionPoint;
    public LayerMask playerLayer;


    private float attackCooldownTimer;
    private int facingDirection = -1;
    private EnemyState enemyState;


    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;

    //start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }


    // Update is called once per frame
    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {


            CheckForPlayer();

            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.linearVelocity = Vector2.zero;

            }
        }
    }

    void Chase()
    {
        if(player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.position) < attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }          
    }
    

    public void ChangeState(EnemyState newState)
    {

        //Exit the current animation
        if(enemyState == EnemyState.Idle)
            anim.SetBool("IsIdle", false);
        else if (enemyState == EnemyState.Chasing)
        anim.SetBool("IsChasing",false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("IsAttacking", false);

        //Update our current state
        enemyState = newState;

        //Update the new animation
        if(enemyState == EnemyState.Idle)
            anim.SetBool("IsIdle", true);
        else if (enemyState == EnemyState.Chasing)
        anim.SetBool("IsChasing",true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("IsAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, attackRange);
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}


public enum EnemyState 
{
    Idle,
    Chasing, 
    Attacking,
    Knockback,
}
