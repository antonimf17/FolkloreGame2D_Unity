using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake : MonoBehaviour
{

    [Header("Enemy System Configuration")]
    [SerializeField] int pointsToGive = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentPoints >= GameManager.Instance.winPoints) { SceneManager.LoadScene(0); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            GameManager.Instance.currentPoints += pointsToGive;

            
        }
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
