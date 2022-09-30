using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject umv;

    private OptionMenu optionMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        EnemyCounter.ResetEnemyCounter();
        Pathfinding.obstacleList?.Clear();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void OpenHowToPlay()
    {
        umv.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        umv.SetActive(false);
    }
}
