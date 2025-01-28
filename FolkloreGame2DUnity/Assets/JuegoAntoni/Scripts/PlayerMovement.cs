using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D PlayerRB;
    private Animator anim;

    private float horizontalInput;
    private float verticalInput;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        PlayerRB.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);


        if (horizontalInput != 0 || verticalInput != 0)
        {

            anim.SetFloat("Horizontal", horizontalInput);
            anim.SetFloat("Vertical", verticalInput);
            anim.SetFloat("Speed", 1);

        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

}
