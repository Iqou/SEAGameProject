using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC_Wander : MonoBehaviour
{
    [Header("Wander Area")]
    public float wanderWidth = 5;
    public float wanderHeight = 5;
    public Vector2 startingPosition;
    public float pauseDuration = 1;
    public float speed = 2;

    private Rigidbody2D rb;
    public Vector2 target;
    private bool isPaused;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        if(isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        if(Vector2.Distance(transform.position, target)<.1f)
            StartCoroutine(PauseAndPickNewDirection());

        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    IEnumerator PauseAndPickNewDirection()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);

        target = GetRandomTarget();
        isPaused = false;
    }

    private void OnEnable()
    {
        target = GetRandomTarget();
    }

    private Vector2 GetRandomTarget()
{
    float halfWidth = wanderWidth / 2;
    float halfHeight = wanderHeight / 2;
    int edge = Random.Range(0, 4);

    return edge switch
    {
        0 => new Vector2(startingPosition.x - halfWidth, Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)),
        1 => new Vector2(startingPosition.x + halfWidth, Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)),
        2 => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y - halfHeight),
        _ => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y + halfHeight),
    };
}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startingPosition,new Vector3(wanderWidth,wanderHeight,0));
    }
}
