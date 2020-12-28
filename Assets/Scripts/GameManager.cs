using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Fields visible in inspector
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject freezetimePanel;
    [SerializeField] private GameObject scoreboard;
    [SerializeField] private Scoreboard scoring;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI gameOverReason;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI playerTime;
    [SerializeField] private TextMeshProUGUI recordTime;

    //Fields available to all scripts
    [HideInInspector] public bool gameInFreeztime = true;
    [HideInInspector] public bool gameIsOver = false;
    [HideInInspector] public bool gameIsPaused = false;

    public void WinGame()
    {
        float currentTime = scoring.timer;
        float record = scoring.GetRecordTime();

        if(currentTime > record)
        {
            recordTime.SetText(currentTime.ToString("#.00"));
            scoring.SetRecordTime(currentTime);
        }

        playerTime.SetText(currentTime.ToString("#.00"));

        player.enabled = false;

        victoryPanel.SetActive(true);
        scoreboard.SetActive(false);
    }
    
    public void GameOver(String reason)
    {
        player.enabled = false;

        if(!gameIsOver)
        {
            gameIsOver = true;
        }

        mainCamera.GetComponent<AudioSource>().Play();

        gameOverReason.SetText(reason);

        scoreboard.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void EndFreeztime()
    {
        Time.timeScale = 1;
        gameInFreeztime = false;
        freezetimePanel.SetActive(false);
        scoreboard.SetActive(true);
    }

    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            scoreboard.SetActive(false);
            gameIsPaused = true;
        }
    }

    public void UnpauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            scoreboard.SetActive(true);
            gameIsPaused = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    //Quits the player to the desktop
    public void QuitGame()
    {
        Application.Quit();
    }
}
