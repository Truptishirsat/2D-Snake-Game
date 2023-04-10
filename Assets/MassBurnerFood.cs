using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBurnerFood : MonoBehaviour
{
    public Collider2D gridArea;
    private Snake snake;
    private MassGainerFood food;
    private float timer = 0.0f;
    private float spawnRange = 12f;
    private Vector3 previousPosition;

    void Awake()
    {
        snake = FindObjectOfType<Snake>();
        food = FindObjectOfType<MassGainerFood>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // randomizing position of food it is no longer chnaged its position or eaten by snake
        if(snake.segments.Count > 2)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

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
            if(snake.segments.Count > 2)
            {
                transform.position = food.RandomizePosition();
                //.GetComponent<SpriteRenderer>().enabled = true;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Snake")
        {
            if(snake.segments.Count > 2)
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
