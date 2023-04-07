using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MassGainerFood : MonoBehaviour
{
    public Collider2D gridArea;
    private Snake snake;
    private MassBurnerFood massBurnerFood;

    private float timer = 0.0f;
    private float spawnRange = 10f;
    private Vector3 previousPosition;
    

    void Awake()
    {
        snake = FindObjectOfType<Snake>();
        massBurnerFood = FindObjectOfType<MassBurnerFood>();

    }
    void Start()
    {
        transform.position = RandomizePosition();
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
            timer = 0f;
        }
        previousPosition = transform.position;


        if(timer >= spawnRange)
        {
            transform.position = RandomizePosition();
        }

    }

    public Vector3  RandomizePosition()
    {
        // Changing the position of food

        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x , bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);


        x = Mathf.Round(x);
        y = Mathf.Round(y);

        // prevent spawning of food at other gameobjects
        while(massBurnerFood.Occupies(x,y) && Occupies(x,y))
        {
            x++;
            if(x > bounds.max.x)
            {
                x = bounds.min.x;

                y++;
                if(y > bounds.max.y)
                {
                    y = bounds.min.y;
                }
            }
        } 
        return new Vector3(x,y,0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Snake")
        {
            transform.position = RandomizePosition();
        }
    }


    //Checks if massgainerfood occupies the given position
    private bool Occupies(float x, float y)
    {
        if((transform.position.x == x) && (transform.position.y == y))
        {
            return true;
        }
        return false;
    }
}
