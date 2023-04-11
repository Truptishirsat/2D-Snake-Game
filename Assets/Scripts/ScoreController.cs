using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private Snake snake;
    private TextMeshProUGUI score_text;
    public WinnerController winner;

    public int winScore;

    void Awake()
    {
        snake = FindObjectOfType<Snake>();
        score_text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score_text.text =  "Score:" + snake.score;
        if(snake.score > winScore)
        {
            winner.OnWin();
        }
    }
}
