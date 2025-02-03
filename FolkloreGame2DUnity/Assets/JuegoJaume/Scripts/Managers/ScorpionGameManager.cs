using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScorpionGameManager : MonoBehaviour
{

    public static ScorpionGameManager instance;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public GameObject winScreen;
    public TMP_Text timerText;
    public float startTime = 150f;
    private float currentTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
        currentTime = startTime;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            currentTime -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (currentTime <= 0)
            {
                currentTime = 0;
                WinGame();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    private void WinGame()
    {
        Debug.Log("You win!");
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}