using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoliderMovement : MonoBehaviour
{
    private bool isFacingRight = true;

    private Rigidbody2D PlayerRB;
    private Animator anim;

    private float horizontalInput;
    private float verticalInput;

    [Header("Movement Parameters")]
    [SerializeField] float speed = 5f;
    private bool canMove = true;  // Nueva variable para bloquear movimiento mientras dispara


    [Header("Attack Parameters")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 2.0f;
    [SerializeField] float delayBeforeShooting = 1.0f;  // Tiempo de retraso antes de disparar




    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Attack();
        if (GameManager.Instance.WolfsKilled >= GameManager.Instance.WolfsKillWin) { SceneManager.LoadScene(0); }
    }


    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
            // Solo se mueve si puede moverse
        }
        else
        {
            PlayerRB.velocity = Vector2.zero;
        }

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
        if (horizontalInput > 0 && !isFacingRight) Flip();
        if (horizontalInput < 0 && isFacingRight) Flip();

    }
    IEnumerator ShootWithDelay()
    {
        canAttack = false;
        canMove = false;
        PlayerRB.velocity = Vector2.zero;  // 🔴 Asegura que el personaje NO se deslice
        yield return new WaitForSecondsRealtime(delayBeforeShooting);  // Espera sin depender del Time.timeScale

        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.transform.right = isFacingRight ? Vector3.right : Vector3.left;
        canMove = true;
        Invoke(nameof(ResetAttack), attackCooldown);
        yield return new WaitForSeconds(attackCooldown);  // Esperar cooldown antes de disparar otra vez
        canMove = true;
        canAttack = true;  // Ahora sí puede volver a disparar
        
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            // Instanciamos el proyectil en el punto de ataque

            anim.SetTrigger("Attack");

            
            StartCoroutine(ShootWithDelay());  // Iniciar la Coroutine
     
        }
    }

    void ResetAttack()
    {
        
        canAttack = true; //Define que podemos atacar
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemyright"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Enemyleft"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }

    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }



}