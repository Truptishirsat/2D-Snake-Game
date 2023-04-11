using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void restart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;

    }
}
