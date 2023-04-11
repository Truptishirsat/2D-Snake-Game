
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public Button restart;
    public Button exit;
   // private Snake snake;

    void Awake()
    {
       // snake = FindObjectOfType<Snake>();
        restart.onClick.AddListener(LoadMainScene);
        exit.onClick.AddListener(LoadLobby);
    }
    void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnSnakeDie()
    {
        gameObject.SetActive(true);
    }


}
