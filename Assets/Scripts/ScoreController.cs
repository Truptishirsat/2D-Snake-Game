using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private Snake snake;
    private SnakeB snakeB;
    private TextMeshProUGUI score_text;
    public TextMeshProUGUI  scoreB_text;
    public WinnerController winner;

    public int winScore;

    void Awake()
    {
        snakeB = FindObjectOfType<SnakeB>();
        snake = FindObjectOfType<Snake>();
        score_text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score_text.text =  "ScoreA: " +  snake.score;
        scoreB_text.text = "ScoreB: " +  snakeB.score;

        if(snake.score > winScore)
        {
            winner.OnWin("SnakeA");
        }

        if(snakeB.score > winScore)
        {
            winner.OnWin("SnakeB");
        }
    }
}
