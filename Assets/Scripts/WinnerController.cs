using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinnerController : MonoBehaviour
{
       
    public Button exit;
    public TextMeshProUGUI winner_text;
    void Awake()
    {
        exit.onClick.AddListener(LoadLobby);
    }
    public void OnWin(string name)
    {
        gameObject.SetActive(true);

        if(name == "SnakeA")
        {
            winner_text.text = "SankeA Won";
        }
        else if(name == "SnakeB")
        {
            winner_text.text = "SankeB Won";

        }
    }

    void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
