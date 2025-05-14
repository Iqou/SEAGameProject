using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public int facing = 1;
    public Rigidbody2D rb;
    public Animator anim;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
        flip();
        }

        anim.SetFloat("horizontal",Mathf.Abs(horizontal));
        anim.SetFloat("vertical",Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal,vertical) * speed;
    }

    void flip()
    {
        facing *= -1;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }
}
    
