using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
   public Button playButton;

   void Awake()
   {
        playButton.onClick.AddListener(LoadMainScene);
   }

   void LoadMainScene()
   {
        SceneManager.LoadScene("MainScene");
   }

}
