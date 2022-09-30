using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

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
    public void RestartLevel()
    {
        EnemyCounter.ResetEnemyCounter();
        Pathfinding.obstacleList.Clear();
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
