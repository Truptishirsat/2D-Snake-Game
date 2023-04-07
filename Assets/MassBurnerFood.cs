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
    }

    void Start()
    {
        transform.position = food.RandomizePosition();
    }

    void Update()
    {
        // randomizing position of food it is no longer chnaged its position or eaten by snake

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
            transform.position = food.RandomizePosition();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Snake")
        {
            transform.position = food.RandomizePosition();
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
