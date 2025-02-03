using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemyright"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
            GameManager.Instance.GameOvercaperucita();
        }
        if (collision.gameObject.CompareTag("Enemyleft"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
            GameManager.Instance.GameOvercaperucita();
        }

    }


}