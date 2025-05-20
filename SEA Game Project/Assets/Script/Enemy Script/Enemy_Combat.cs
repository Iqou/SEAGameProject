using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockbackForce;
    public float stunTime;
    public LayerMask playerLayer;
    Audiomanager Audiomanager;

    private void Awake(){
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }


    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0) {
            Playgetattack();
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<Movement>().Knockback(transform, knockbackForce, stunTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
    
    void Playgetattack(){
        Audiomanager.PlaySFX(Audiomanager.playergethit);
    }
    void playorcattack(){
        Audiomanager.PlaySFX(Audiomanager.orcattack);
    }
}
