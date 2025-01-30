using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables de referencia 
    private Animator anim;
    private Rigidbody2D PlayerRB;

    //Variables de estadisticas del player
    private Vector3 Velocity;
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
    private void FixedUpdate()
    {
        PlayerRB.MovePosition(transform.position + Velocity * Time.fixedDeltaTime);

    }

    void Movement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0 && ver != 0)
        {
            anim.SetFloat("Horizontal", hor);
            anim.SetFloat("Vertical", ver);
            anim.SetFloat("Speed", 1);

            Vector3 direction = (Vector3.up * ver + Vector3.right * hor).normalized;
            Velocity = Vector3.zero;
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemyright"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Enemyleft"))
                {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
    }


}
