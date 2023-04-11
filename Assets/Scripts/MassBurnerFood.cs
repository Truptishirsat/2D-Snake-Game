using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBurnerFood : MonoBehaviour
{
    public Collider2D gridArea;
    private Snake snake;
    private SnakeB snakeB;
    private MassGainerFood food;
    private float timer = 0.0f;
    private float spawnRange = 12f;
    private Vector3 previousPosition;

    void Awake()
    {
        snake = FindObjectOfType<Snake>();
        snakeB = FindObjectOfType<SnakeB>();
        food = FindObjectOfType<MassGainerFood>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        // randomizing position of food it is no longer chnaged its position or eaten by snake
        if(((snake.segments.Count) > 2 && (snake.score > 3)) && ((snakeB.segments.Count > 2) && (snakeB.score > 3)))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }

        if(previousPosition == transform.position)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }

        previousPosition = transform.position;

        if(timer >= spawnRange)
        {
            if(((snake.segments.Count > 2) && (snake.score > 3)) && ((snakeB.segments.Count > 2) && (snakeB.score > 3)))
            {
                transform.position = food.RandomizePosition();
                //.GetComponent<SpriteRenderer>().enabled = true;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Snake" || other.tag == "SnakeB")
        {
            if(((snake.segments.Count > 2) && (snake.score > 3)) && ((snakeB.segments.Count > 2) && (snakeB.score > 3)) )
            {
                transform.position = food.RandomizePosition();
               // gameObject.GetComponent<SpriteRenderer>().enabled = true;

            }
        }
    }

    //Checks if massburnerfood occupies the given position
    public  bool Occupies(float x, float y)
    {
        if((transform.position.x == x) && (transform.position.y == y))
        {
            return true;
        }
        return false;
    }
}
