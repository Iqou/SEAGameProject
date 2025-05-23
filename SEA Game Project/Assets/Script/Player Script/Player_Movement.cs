using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int facing = 1;
    public Rigidbody2D rb;
    public Animator anim;
    public Player_Combat player_Combat;

    private bool isKnockedback;
    public bool isShooting;
    public float footstepDelay = 0.4f;
    private float nextFootstepTime = 0f;

    Audiomanager Audiomanager;

    private void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    }

    private void Awake(){
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called 50x per frame
    void FixedUpdate()
    {

        if (isShooting == true)
        {
            rb.linearVelocity = Vector2.zero;
 
        }

        else if (isKnockedback == false)
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            Vector2 movement = new Vector2(horizontal, vertical);
            rb.linearVelocity = movement * StatsManager.instance.speed;
            if (movement.magnitude > 0.1f)
            {
                if (Time.time >= nextFootstepTime)
                {
                    PlayFootsteps();
                    nextFootstepTime = Time.time + footstepDelay;
                }
            }
            
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
    void PlayFootsteps(){
        Audiomanager.PlaySFX(Audiomanager.walking);
    }
    public void setzero()
    {
        transform.position = Vector3.zero;
    }
}

