using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("GroundDetection")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    
    private Rigidbody2D rb;

    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);



        if (move > 0)
            transform.localScale = new Vector3(3, 2, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-3, 2, 1);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 4f;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 7f;
        }
        else
        {
            rb.gravityScale = 3f;
        }



        if (isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
}
