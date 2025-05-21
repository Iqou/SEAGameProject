using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public StatsUI statsUI;
    public Animator anim;

    public float cooldown = 1;
    private float timer;

    Audiomanager Audiomanager;

    private void Awake(){
        DontDestroyOnLoad(gameObject);
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }

    private void Update()
    {
        if (timer > 0 )
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            PlayAttack();
            anim.SetBool("isAttacking", true);
            timer = cooldown;
        } 
    }

    public void DealDamage()
    {
        
        statsUI.UpdateDamage();
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.instance.damage);
            enemies[0].GetComponent<Enemy_Knockback>().Knockback(transform, StatsManager.instance.knockbackForce, StatsManager.instance.knockbackTime, StatsManager.instance.stunTime);
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, StatsManager.instance.weaponRange);
    }

    void PlayAttack(){
        Audiomanager.PlaySFX(Audiomanager.attackhit);
    }



}
