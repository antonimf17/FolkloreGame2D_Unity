using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float speed = 10f; // Velocidad de la bala
    private Rigidbody2D rb;
    public int pointsToGive = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // En este caso, se mueve en la dirección del eje X.
        // Si el jugador mira hacia la derecha, la bala se moverá a la derecha, si no, a la izquierda.
        // La dirección del movimiento depende de la dirección que tenga el personaje (la variable 'isFacingRight')
        Vector2 direction = transform.right;  // Esto mueve la bala en la dirección hacia la derecha
        rb.velocity = direction * speed;  // Asignamos la velocidad en esa dirección
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemyright"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
            GameManager.Instance.WolfsKilled += pointsToGive;

        }
        if (collision.gameObject.CompareTag("Enemyleft"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);

            GameManager.Instance.WolfsKilled += pointsToGive;

        }
        if (collision.gameObject.CompareTag("obstacle"))
            {
           
         gameObject.SetActive(false);
        }
    }

}
