using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMovement enemy_Movement;
    Audiomanager Audiomanager;

    private void Awake(){
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy_Movement = GetComponent<EnemyMovement>();
    }

    public void Knockback(Transform forceTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        enemy_Movement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime,stunTime));
        Vector2 direction = (transform.position - forceTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
        Debug.Log("knockback applied.");
        orcgethit();
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemy_Movement.ChangeState(EnemyState.Idle);
    }

    void orcgethit(){
         Audiomanager.PlaySFX(Audiomanager.orcgethit);
     }

}

