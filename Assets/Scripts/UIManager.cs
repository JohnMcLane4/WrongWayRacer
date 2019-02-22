using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject player;

    public TMP_Text scoreText;
    int score;
   
    void Start()
    {
        InvokeRepeating("IsPlayerDead", 0, 1.0f);
        player = GameObject.FindGameObjectWithTag("Player");

        score = 0;
        InvokeRepeating("ScoreCounter", 0, 0.5f);
    }
    // Update is called once per frame
    void Update ()
    {
        scoreText.text = "Score: " + score;
	}

    void ScoreCounter()
    {
        score += 1;
    }

    void IsPlayerDead()
    {
        if (player == null)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
            GameIsPaused = true;
        }
        else
        {
            gameOverMenu.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = false;
        }
    }

    public void Pause()
    {
        if (GameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }    

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the application");
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);       
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
