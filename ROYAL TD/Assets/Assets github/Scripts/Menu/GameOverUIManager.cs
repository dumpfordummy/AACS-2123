using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameCompleteMenu;

    private void OnEnable()
    {
        TowerHp.OnTownHallDestroy += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        TowerHp.OnTownHallDestroy -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void EnableGameCompleteMenu()
    {
        gameCompleteMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
