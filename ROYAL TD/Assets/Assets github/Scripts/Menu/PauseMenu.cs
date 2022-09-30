using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPauseGame;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPauseGame)
            {
                Pause();
            }
            else if (isPauseGame)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPauseGame = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauseGame = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        EnemyCounter.ResetEnemyCounter();
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
