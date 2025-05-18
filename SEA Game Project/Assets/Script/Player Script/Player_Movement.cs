using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int facing = 1;
    public Rigidbody2D rb;
    public Animator anim;
    public Player_Combat player_Combat;

    private bool isKnockedback;

    private void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called 50x per frame
    void FixedUpdate()
    {
        if (isKnockedback == false)
        {



            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.instance.speed;
        }
    }

    void flip()
    {
        facing *= -1;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedback = false;
    }

    public void Knockback(Transform enemy)
    {

    }

}

