using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController2 : MonoBehaviour
{
    [Header("Enemy Move Parameters")]
    [SerializeField] float speed;
    [SerializeField] float limitX = -10;




    [Header("kill")]



    [Header("General References")]
    [SerializeField] GameObject enemyBody;
    [SerializeField] BoxCollider2D enemyCol;
    [SerializeField] Animator enemyAnim;



    private void Awake()
    {
        enemyCol = GetComponent<BoxCollider2D>();
        enemyAnim = enemyBody.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        if (transform.position.x >= limitX) gameObject.SetActive(false);


    }



    void EnemyMove()
    {

        if (gameObject.CompareTag("Enemyright"))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemyleft"))
        {
            collision.gameObject.SetActive(false);

            gameObject.SetActive(false);

        }
    }
}

