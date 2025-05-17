using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Animator anim;

    public float cooldown = 1;
    private float timer;

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
            anim.SetBool("isAttacking", true);
            timer = cooldown;
        }
    }
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
