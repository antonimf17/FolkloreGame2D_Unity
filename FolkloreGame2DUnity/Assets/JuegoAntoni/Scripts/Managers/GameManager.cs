using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance != null) Debug.Log("Jugando");
            return instance;
        }
    }
    public int currentPoints;
    public int winPoints;
    public int WolfsKilled;
    public int WolfsKillWin;
    public TMP_Text timerText;
    public float startTime = 150f;
    private float currentTime;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public GameObject winScreen;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void Update()
    {
        Time.timeScale = 1f;

        if (GameManager.Instance.WolfsKilled >= GameManager.Instance.WolfsKillWin) { WinGamesoldier(); }
        if (GameManager.Instance.currentPoints >= GameManager.Instance.winPoints) { WinGamecaperucita(); }

    }

    public void GameOversoldier()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        WolfsKilled = 0;

    }

    public void RestartGamesoldier()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        WolfsKilled = 0;
      
    }

    private void WinGamesoldier()
    {
        Debug.Log("You win!");
        winScreen.SetActive(true);
        WolfsKilled = 0;
        
    }
    private void WinGamecaperucita()
    {
        Debug.Log("You win!");
        winScreen.SetActive(true);
        currentPoints = 0;
    }
    public void RestartGamecaperucita()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentPoints = 0;
    }
    public void GameOvercaperucita()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        currentPoints = 0;
    }
}