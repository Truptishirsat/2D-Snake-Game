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
    void Awake()
    {
        exit.onClick.AddListener(LoadLobby);
    }
    public void OnWin()
    {
        gameObject.SetActive(true);
    }

    void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
